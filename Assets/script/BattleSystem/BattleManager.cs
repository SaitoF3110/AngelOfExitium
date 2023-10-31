using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>バトルの全体管理</summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>現在ターン数</summary>
    int _turn = 0;
    /// <summary>バトルオブジェクトの位置</summary>
    Dictionary<GameObject, Vector2[]> _ObjectPositions;

    void Start()
    {
        
    }

    void Update()
    {
        
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
