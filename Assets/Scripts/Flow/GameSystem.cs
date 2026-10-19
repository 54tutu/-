using System;
using UnityEngine;

/// <summary>
/// 游戏系统：承载单局玩法逻辑
/// 生命周期：GameInit → GameBegin → [玩法运行中] → GameEnd → GameEndInit
/// </summary>
public class GameSystem
{
    /// <summary>单局结束事件（由玩法内部调用 TriggerGameOver 触发）</summary>
    public event Action OnGameOver;

    // ==================== 生命周期接口 ====================

    /// <summary>游戏初始化</summary>
    public void GameInit()
    {
        Debug.Log("游戏初始化");
        // TODO: 
        // - 初始化玩家 / 对手剑坯（BASE_VALUE = 100）
        // - 初始化回合数（ROUND_COUNT）、胜利条件（WIN_CONDITION）
        // - 初始化锤数（HAMMER_COUNT）、时限、入神累计
        // - 初始化道具槽位（最多 3 个带入）
    }

    /// <summary>游戏开始</summary>
    public void GameBegin()
    {
        Debug.Log("游戏开始");
        // TODO: 
        // - 启动第一回合
        // - 启动每锤 10 秒倒计时
        // - 启动对手快照同步播放
    }

    /// <summary>游戏结束</summary>
    public void GameEnd()
    {
        Debug.Log("游戏结束");
        // TODO: 
        // - 判定整局胜负
        // - 结算段位积分 / 金币
        // - 比较并更新「最强剑」
        // - 记录埋点（胜负、双方价值、金币获取）
    }

    /// <summary>游戏数据结束初始化（重置对局临时数据，准备下一局）</summary>
    public void GameEndInit()
    {
        Debug.Log("游戏数据结束初始化");
        // TODO: 
        // - 清空本局临时数据（剑坯、锤数、入神累计、道具状态）
        // - 清空对手快照
        // - 重置 GameSystem 内部状态
    }

    // ==================== 玩法预留接口（后续填实现） ====================

    /// <summary>锤击一次（普通状态）</summary>
    public void HammerHit() { /* TODO */ }

    /// <summary>进入入神状态</summary>
    public void EnterEnshrine() { /* TODO */ }

    /// <summary>入神结束</summary>
    public void ExitEnshrine() { /* TODO */ }

    /// <summary>使用道具</summary>
    public void UseItem(string itemId) { /* TODO */ }

    /// <summary>触发一次入神（内部由累计锤数阈值判断）</summary>
    public void CheckEnshrineTrigger() { /* TODO */ }

    /// <summary>对局结束触发（供玩法内部调用）</summary>
    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }
}