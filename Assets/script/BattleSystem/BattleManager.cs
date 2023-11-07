using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>�o�g���̑S�̊Ǘ�</summary>
public class BattleManager : MonoBehaviour
{
    /// <summary>���݃^�[����</summary>
    int _turn = 0;
    /// <summary>�o�g���I�u�W�F�N�g�̈ʒu</summary>
    public Dictionary<GameObject, Vector2[]> _ObjectPositions = new Dictionary<GameObject, Vector2[]>();//�ʒu����������G������
    /// <summary>�o�g���I�u�W�F�N�g���ړ��������ǂ���</summary>
    public bool _isMoved = false;

    /// <summary>�L�����N�^�[�̃|�W�V����</summary>
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
        Turn();
    }
    /// <summary>�퓬���̑S�L�����N�^�[�I�u�W�F�N�g�Ƃ��̈ʒu��n��</summary>
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
    /// <summary>ITurn�̐���</summary>
    void Turn()
    {
        var objects = FindObjectsOfType<GameObject>();
        foreach (var obj in objects)
        {
            //�Ƃ肠�����e�L�g�[
            //��ŕK�v�ɂȂ������C��
            ITurn i = obj.GetComponent<ITurn>();
            if (Input.GetKeyDown(KeyCode.Z))
            {
                i?.Friend();
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                i?.FriendAction();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                i?.Enemy();
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                i?.EnemyAction();
            }
        }
    }
}
