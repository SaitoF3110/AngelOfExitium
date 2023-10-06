using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterDeta")]
public class CharacterData : ScriptableObject
{
    [Tooltip("キャラクター名")]
    /// <summary>キャラクター名</summary>
    public string _name;
    /// <summary>キャラクターID</summary>
    public int _chatacterID;//保存時に使う
    //↓各ステータス
    /// <summary>初期攻撃力</summary>
    public int _defaultAttack;
    /// <summary>初期防御力</summary>
    public int _defaultDiffence;
    /// <summary>初期体力</summary>
    public int _defaultHealth;
    /// <summary>初期スキルポイント</summary>
    public int _defaultSp;
    //↓レベルが上がった時の上昇量設定
    /// <summary>攻撃力上昇量</summary>
    public int _incAttack;
    /// <summary>防御力上昇量</summary>
    public int _incDiffence;
    /// <summary>体力上昇量</summary>
    public int _incHealth;
    /// <summary>スキルポイント上昇量</summary>
    public int _incSp;

    /// <summary>最大レベル</summary>
    public int _maxLevel;//この数値まで到達可
}
