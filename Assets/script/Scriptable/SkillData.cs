using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/SkillDeta")]
/// <summary>�X�L���f�[�^�B�G��������Ȃ�</summary>
public class SkillData : ScriptableObject
{
    /// <summary>�X�L����</summary>
    public string _skillName;
    /// <summary>�X�L������</summary>
    public string[] _skillInfo;
    /// <summary>�X�L��ID�ۑ����Ɏg�p</summary>
    public int _skillID;

    //�X�L���Ώ۔͈͐ݒ聫��
    /// <summary>�U������</summary>
    [Tooltip("0=�U�����Ȃ��@1�`�U�������@99=�I���\")]
    public int _range;
    /// <summary>�U���͈�</summary>
    [Tooltip("�L�����N�^�[���猩���U���̉���")]
    [Range(1, 10)]
    public int _width = 1;
    /// <summary>�U���ђ�</summary>
    [Tooltip("�U���������̓G�����̊ђʂ��邩")]
    [Range(0, 10)]
    public int _penetratValue = 0;
    /// <summary>(_range=0)�����w��</summary>
    [Tooltip("_range��0�̎��ATrue�Ŗ����S�����w�肷��X�L���ɂȂ�")]
    public bool _allTarget = false;

    //�P���X�L������
    [Tooltip("�g�p�L�����̍U���͂Ɋ�Â��X�L����HP�����ʁB�p�[�Z���e�[�W�Ŏw��B\n�}�C�i�X�̒l�͉񕜌��ʂɂȂ�")]
    public int _damage = 100;

    //�^�[���p���n�X�L������
    [Tooltip("�g�p�L�����̍U���͂Ɋ�Â��U���͏㏸�ʁB�p�[�Z���e�[�W�Ŏw��B")]
    public int _attackPercentage = 100;
    [Tooltip("�g�p�L�����̖h��͂Ɋ�Â��h��͏㏸�ʁB�p�[�Z���e�[�W�Ŏw��B")]
    public int _diffencePercentage = 100;
}
