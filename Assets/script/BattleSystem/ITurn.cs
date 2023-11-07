interface ITurn
{
    /// <summary>味方の行動選択ターン</summary>
    void FriendAction();
    /// <summary>味方の攻撃ターン</summary>
    void Friend();
    /// <summary>敵の行動選択ターン</summary>
    void EnemyAction();
    /// <summary>敵の攻撃ターン</summary>
    void Enemy();
}