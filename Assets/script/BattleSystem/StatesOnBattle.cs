using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>�L�����N�^�[���Ƃ̃o�g�����̈ꎞ�X�e�[�^�X </summary>
public class StatesOnBattle : MonoBehaviour
{
    [SerializeField] CharacterData _character;
    int _health;
    int _attack;
    int _diffence;
    int _sp;
    /// <summary>���݂̍��W</summary>
    Vector2 _position = new Vector2(0,0);
    /// <summary>�v�Z�p�U���G���A�B[�}�X�ڂ̐�,x���W,y���W]</summary>
    public int[,,] _areaOnSystem;
    void Start()
    {
        //�Ƃ肠���������l�Ŏ擾
        //�����A�o�t�f�o�t�̏����͌�ق�
        _attack = _character._defaultAttack;
        _diffence = _character._defaultDiffence;
        //�����ʒu�̏�����������
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
