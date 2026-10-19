using UnityEngine;
using UnityEngine.UI;

public class StartGameBtn : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Awake()
    {
        if (startButton == null) startButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (startButton != null) startButton.onClick.AddListener(OnStartClicked);
    }

    private void OnDisable()
    {
        if (startButton != null) startButton.onClick.RemoveListener(OnStartClicked);
    }

    private void OnStartClicked()
    {
        if (GameFlowManager.Instance == null)
        {
            Debug.LogError("[StartGameBtn] 场景中未找到 GameFlowManager");
            return;
        }

        // 直接通知 Manager 开始流程，Manager 会去处理场景加载
        GameFlowManager.Instance.StartGameFlow();
    }
}