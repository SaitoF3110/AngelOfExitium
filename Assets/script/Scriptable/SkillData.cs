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

}
