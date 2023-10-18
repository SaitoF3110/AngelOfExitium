using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>�o�g�����̈ꎞ�X�e�[�^�X </summary>
public class StatesOnBattle : MonoBehaviour
{
    [SerializeField] CharacterData _character;
    int _health;
    int _attack;
    int _diffence;
    int _sp;
    /// <summary>���݂̍��W</summary>
    int[] _position = new int[2] {0,0};
    /// <summary>�v�Z�p�U���G���A�B[�}�X�ڂ̐�,x���W,y���W]</summary>
    public int[,,] _areaOnSystem;
    void Start()
    {
        //�Ƃ肠���������l�Ŏ擾
        _attack = _character._defaultAttack;
        _diffence = _character._defaultDiffence;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AreaConvert(0);
        }
    }
    /// <summary>�ϊ��������X�L���ԍ����󂯎��܂��B</summary>
    public int[] AreaConvert(int _skillNum)
    {
        int _length = 0;
        //_areaOnSystem = new int[_character._skills[_skillNum]._attackArea.Length,8, 5];
        for(int i = 0;i < _character._skills[_skillNum]._attackArea.Length; i++)
        {
            //_attackArea�̐��������W�n�ɕϊ��@��j�ꏊ25��4,4
            _areaOnSystem[i, _character._skills[_skillNum]._attackArea[i] / 5,
                _character._skills[_skillNum]._attackArea[i] % 5] = 1;
            _length = i;
        }
        return new int[] { 1, 1, 1 };
    }
}
