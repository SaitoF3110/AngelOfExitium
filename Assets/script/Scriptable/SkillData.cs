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

}
