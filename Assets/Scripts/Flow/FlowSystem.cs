using UnityEngine;

/// <summary>
/// 流程系统：管理「进入流程 → 流程初始化 → 流程结束」
/// 负责进入游戏界面之前的准备工作
/// </summary>
public class FlowSystem
{
    /// <summary>进入流程系统（唯一入口的前半段）</summary>
    public void Init()
    {
        Debug.Log("进入流程");
        // TODO: 流程上下文初始化（如本局唯一ID、进入时间戳、流程标记）
    }

    /// <summary>流程系统开始（Init 之后调用，可在此做资源预加载等）</summary>
    public void Begin()
    {
        // TODO: 预加载通用资源、构建流程环境（此处可选，也可直接走 FlowInit）
    }

    /// <summary>
    /// 流程系统初始化：进入游戏界面之前的初始化操作
    /// （加载游戏界面、准备 UI、初始化对手数据源等）
    /// </summary>
    public void FlowInit()
    {
        Debug.Log("流程系统初始化");
        // TODO: 
        // 1. 加载游戏界面 / 剑坯 / 道具图标等资源
        // 2. 初始化游戏界面 UI（未打开，仅准备）
        // 3. 初始化段位 / 对手快照 等全局数据
    }

    /// <summary>流程结束</summary>
    public void FlowEnd()
    {
        Debug.Log("流程结束");
        // TODO: 释放流程资源、清空流程上下文、回到主界面
    }
}