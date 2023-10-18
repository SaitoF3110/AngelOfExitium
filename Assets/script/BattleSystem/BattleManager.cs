using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>バトルの全体管理</summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>現在ターン数</summary>
    int _turn = 0;
    /// <summary>バトルオブジェクト（種類）</summary>
    GameObject[] _battleObjType;
    /// <summary>バトルオブジェクトの位置[x座標,y座標]</summary>
    GameObject[,] _objectPosition = new GameObject[8,4];
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
