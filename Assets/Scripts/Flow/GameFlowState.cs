/// <summary>
/// 流程状态枚举（用于外部查询、埋点、UI 状态切换）
/// </summary>
public enum GameFlowState
{
    None,           // 空闲
    FlowEnter,      // 进入流程系统
    FlowInit,       // 流程系统初始化（进入游戏界面之前）
    GameInit,       // 游戏初始化
    GameBegin,      // 游戏开始
    GamePlaying,    // 游戏进行中（玩法逻辑运行）
    GameEnd,        // 游戏结束
    GameEndInit,    // 游戏数据结束初始化
    FlowEnd         // 流程结束
}