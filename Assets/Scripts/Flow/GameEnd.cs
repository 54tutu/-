using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Button returnButton;

    private void Awake()
    {
        if (returnButton == null) returnButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (returnButton != null) returnButton.onClick.AddListener(OnReturnClicked);
    }

    private void OnDisable()
    {
        if (returnButton != null) returnButton.onClick.RemoveListener(OnReturnClicked);
    }

    private void OnReturnClicked()
    {
        if (GameFlowManager.Instance != null)
        {
            // 通知 Manager 结束流程，Manager 会打印结束文本并切回 StartGame 场景
            GameFlowManager.Instance.EndGameFlow();
        }
        else
        {
            Debug.LogError("[GameEnd] 找不到 GameFlowManager，无法结束流程！");
        }
    }
}