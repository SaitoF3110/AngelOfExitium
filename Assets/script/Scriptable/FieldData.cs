using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/FieldDeta")]
/// <summary>各フィールドのデータ</summary>
public class FieldData : ScriptableObject
{
    /// <summary>フィールド名</summary>
    public string _fieldName;
    /// <summary>フィールド詳細</summary>
    public string[] _fieldInfo;
    /// <summary>フィールド特殊環境</summary>
    public string[] _fieldEnvironment;
    /// <summary>黒雲浄化判定</summary>
    public bool _blackCloud = false;

    /// <summary>フィールドシンボル</summary>
    public Sprite _fieldImage;
    /// <summary>フィールドシンボルのスケール</summary>
    public float _fieldImageScale = 1;

    /// <summary>ステージ「ストーリー」</summary>
    public GameObject[] _stagesStory;
    /// <summary>ステージ「その他」</summary>
    public GameObject[] _stagesOther;
}
