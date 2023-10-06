using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterDeta")]
public class CharacterData : ScriptableObject
{
    [Tooltip("�L�����N�^�[��")]
    /// <summary>�L�����N�^�[��</summary>
    public string _name;
    /// <summary>�L�����N�^�[ID</summary>
    public int _chatacterID;//�ۑ����Ɏg��
    //���e�X�e�[�^�X
    /// <summary>�����U����</summary>
    public int _defaultAttack;
    /// <summary>�����h���</summary>
    public int _defaultDiffence;
    /// <summary>�����̗�</summary>
    public int _defaultHealth;
    /// <summary>�����X�L���|�C���g</summary>
    public int _defaultSp;
    //�����x�����オ�������̏㏸�ʐݒ�
    /// <summary>�U���͏㏸��</summary>
    public int _incAttack;
    /// <summary>�h��͏㏸��</summary>
    public int _incDiffence;
    /// <summary>�̗͏㏸��</summary>
    public int _incHealth;
    /// <summary>�X�L���|�C���g�㏸��</summary>
    public int _incSp;

    /// <summary>�ő僌�x��</summary>
    public int _maxLevel;//���̐��l�܂œ��B��
}
