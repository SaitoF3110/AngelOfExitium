using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/FieldDeta")]
/// <summary>�e�t�B�[���h�̃f�[�^</summary>
public class FieldData : ScriptableObject
{
    /// <summary>�t�B�[���h��</summary>
    public string _fieldName;
    /// <summary>�t�B�[���h�ڍ�</summary>
    public string[] _fieldInfo;
    /// <summary>�t�B�[���h�����</summary>
    public string[] _fieldEnvironment;
    /// <summary>���_�򉻔���</summary>
    public bool _blackCloud = false;

    /// <summary>�t�B�[���h�V���{��</summary>
    public Sprite _fieldImage;
    /// <summary>�t�B�[���h�V���{���̃X�P�[��</summary>
    public float _fieldImageScale = 1;

    /// <summary>�X�e�[�W�u�X�g�[���[�v</summary>
    public GameObject[] _stagesStory;
    /// <summary>�X�e�[�W�u���̑��v</summary>
    public GameObject[] _stagesOther;
}
