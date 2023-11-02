using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>バトルの全体管理</summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>現在ターン数</summary>
    int _turn = 0;
    /// <summary>バトルオブジェクトの位置</summary>
    public Dictionary<GameObject, Vector2[]> _ObjectPositions = new Dictionary<GameObject, Vector2[]>();//位置が複数ある敵もいる

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CharactorPositions();
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
    /// <summary>ITurnの制御</summary>
    void Turn()
    {
        var objects = FindObjectsOfType<GameObject>();
        foreach (var obj in objects)
        {
            //とりあえずテキトー
            //後で必要になった時修正
            ITurn i = obj.GetComponent<ITurn>();
            if (1 + 1 == 0)
            {
                i?.Friend();
            }
            else if (1 == 1)
            {
                i?.FriendAction();
            }
            else if (1 == 1)
            {
                i?.Enemy();
            }
        }
    }
}
