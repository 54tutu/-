using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public static GameFlowManager Instance { get; private set; }

    private FlowSystem _flowSystem;
    private GameSystem _gameSystem;

    public GameFlowState CurrentState { get; private set; } = GameFlowState.None;
    public event Action<GameFlowState> OnStateChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // 保证跨场景不销毁
        DontDestroyOnLoad(gameObject);

        _flowSystem = new FlowSystem();
        _gameSystem = new GameSystem();
    }

    // ==================== 开始游戏流程 ====================

    /// <summary>由开始按钮调用</summary>
    public void StartGameFlow()
    {
        if (CurrentState != GameFlowState.None)
        {
            Debug.LogWarning("已有流程在运行中！");
            return;
        }

        // 1. 打印前置准备文本
        SetState(GameFlowState.FlowEnter);
        _flowSystem.Init();      // 打印「进入流程」

        SetState(GameFlowState.FlowInit);
        _flowSystem.Begin();
        _flowSystem.FlowInit();  // 打印「流程系统初始化」

        // 2. 开始加载 Game 场景（由常驻的 Manager 开启协程）
        StartCoroutine(LoadGameSceneAndStartFlow());
    }

    private IEnumerator LoadGameSceneAndStartFlow()
    {
        Debug.Log("开始异步加载 Game 场景...");

        // 异步加载 Game 场景
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("Game 场景加载完毕，开始执行游戏系统...");

        // 3. 进入游戏系统
        SetState(GameFlowState.GameInit);
        _gameSystem.GameInit();   // 打印「游戏初始化」

        SetState(GameFlowState.GameBegin);
        _gameSystem.GameBegin();  // 打印「游戏开始」

        SetState(GameFlowState.GamePlaying);
        Debug.Log("游戏进行中...");
    }

    // ==================== 结束游戏流程 ====================

    /// <summary>由返回大厅按钮调用</summary>
    public void EndGameFlow()
    {
        if (CurrentState != GameFlowState.GamePlaying)
        {
            Debug.LogWarning($"当前不在游戏进行中，无法结束！当前状态：{CurrentState}");
            return;
        }

        // 4. 打印结束文本
        SetState(GameFlowState.GameEnd);
        _gameSystem.GameEnd();       // 打印「游戏结束」

        SetState(GameFlowState.GameEndInit);
        _gameSystem.GameEndInit();   // 打印「游戏数据结束初始化」

        SetState(GameFlowState.FlowEnd);
        _flowSystem.FlowEnd();       // 打印「流程结束」

        // 5. 返回主场景并重置状态
        CurrentState = GameFlowState.None;
        Debug.Log("准备返回 StartGame 场景...");
        SceneManager.LoadScene("StartGame");
    }

    private void SetState(GameFlowState state)
    {
        CurrentState = state;
        Debug.Log($"[GameFlow] 状态切换 → {state}");
        OnStateChanged?.Invoke(state);
    }
}