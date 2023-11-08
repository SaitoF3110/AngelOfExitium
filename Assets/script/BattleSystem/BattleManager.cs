using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>バトルの全体管理</summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>バトルオブジェクトの位置</summary>
    public Dictionary<GameObject, Vector2[]> _ObjectPositions = new Dictionary<GameObject, Vector2[]>();//位置が複数ある敵もいる
    /// <summary>バトルオブジェクトが移動したかどうか</summary>
    public bool _isMoved = false;

    /// <summary>キャラクターのポジション</summary>
    event Action<GameObject[], Vector2[][]> _charaPosi;
    public Action<GameObject[], Vector2[][]> CharaPosition
    {
        get { return _charaPosi; }
        set { _charaPosi = value; }
    }
    void Start()
    {

    }

    void Update()
    {
        CharactorPositions();
        if(Input.GetKeyDown(KeyCode.M))
        {
            foreach (KeyValuePair<GameObject, Vector2[]> item in _ObjectPositions)
            {
                Debug.Log("キャラ：" + item.Key + "　位置" + item.Value[0]);
            }
        }
    }
    /// <summary>戦闘中の全キャラクターオブジェクトとその位置を渡す</summary>
    void CharactorPositions()
    {
        GameObject[] characters = new GameObject[_ObjectPositions.Count];
        Vector2[][] vector2s = new Vector2[_ObjectPositions.Count][];
        int i = 0;
        foreach (GameObject character in _ObjectPositions.Keys)
        {
            characters[i] = character;
            vector2s[i] = _ObjectPositions[character];
            i++;
        }
        _charaPosi(characters,vector2s);
    }
}
