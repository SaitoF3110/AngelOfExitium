using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>�o�g���̑S�̊Ǘ�</summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>���݃^�[����</summary>
    int _turn = 0;
    /// <summary>�o�g���I�u�W�F�N�g�̈ʒu</summary>
    Dictionary<GameObject, Vector2[]> _ObjectPositions;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    /// <summary>ITurn�̐���</summary>
    void Turn()
    {
        var objects = FindObjectsOfType<GameObject>();
        foreach (var obj in objects)
        {
            //�Ƃ肠�����e�L�g�[
            //��ŕK�v�ɂȂ������C��
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
