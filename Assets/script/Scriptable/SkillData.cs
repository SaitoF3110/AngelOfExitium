using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/SkillDeta")]
/// <summary>スキルデータ。敵味方を問わない</summary>
public class SkillData : ScriptableObject
{
    /// <summary>スキル名</summary>
    public string _skillName;
    /// <summary>スキル説明</summary>
    public string[] _skillInfo;
    /// <summary>スキルID保存時に使用</summary>
    public int _skillID;

    //スキルによる消費↓↓
    /// <summary>消費SP</summary>
    public int _spendSP;
    /// <summary>消費HP</summary>
    public int _spendHP;

    //スキル対象範囲設定↓↓
    /// <summary>攻撃エリア。範囲図参照。</summary>
    [Tooltip("0=攻撃しない")]
    public int[] _attackArea;

    /// <summary>攻撃距離</summary>
    [Tooltip("0=攻撃しない　1～攻撃距離　99=選択可能")]
    public int _range;
    /// <summary>攻撃範囲</summary>
    [Tooltip("キャラクターから見た攻撃の横幅")]
    [Range(1, 10)]
    public int _width = 1;
    /// <summary>攻撃貫通</summary>
    [Tooltip("攻撃が横列上の敵を何体貫通するか")]
    [Range(0, 10)]
    public int _penetratValue = 0;
    /// <summary>(_range=0)味方指定</summary>
    [Tooltip("_rangeが0の時、Trueで味方全員を指定するスキルになる")]
    public bool _allTarget = false;

    //与えるエフェクト↓↓
    [Tooltip("エフェクトの種類")]
    public EffectEnum.Effect _effect = 0;
    [Tooltip("エフェクトの持続時間")]
    public int _effectTurn = 0;

    //単発スキル↓↓
    [Tooltip("使用キャラの攻撃力に基づくスキルのHP増減量。パーセンテージで指定。\nマイナスの値は回復効果になる")]
    public int _damage = 100;

    //ターン継続系スキル↓↓
    [Tooltip("使用キャラの攻撃力に基づく攻撃力上昇量。パーセンテージで指定。")]
    public int _attackPercentage = 100;
    [Tooltip("使用キャラの防御力に基づく防御力上昇量。パーセンテージで指定。")]
    public int _diffencePercentage = 100;
}
