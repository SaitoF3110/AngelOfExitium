using System;
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
    SkillManager _skillData;
    BattleManager _battleManager;
    /// <summary>���݂̍��W</summary>
    Vector2[] _position = new Vector2[1] {new Vector2(1,1)};
    /// <summary>�v�Z�p�U���G���A�B[�}�X�ڂ̐�,x���W,y���W]</summary>
    public int[,,] _areaOnSystem;

    void Start()
    {
        //�Ƃ肠���������l�Ŏ擾
        //�����A�o�t�f�o�t�̏����͌�ق�
        _attack = _character._defaultAttack;
        _diffence = _character._defaultDiffence;
        //�����ʒu�̏�����������

        //�f���Q�[�g�̓o�^
        _skillData = GameObject.FindObjectOfType<SkillManager>();
        _skillData.SkillArea += UnderAttack;
        _position[0] = new Vector2(-1,-1);

        _battleManager = GameObject.FindObjectOfType<BattleManager>();
        //���g�̈ʒu��o�^
        _battleManager._ObjectPositions.Add(this.gameObject, _position);
    }

    void Update()
    {
        //���g�̈ʒu���}�l�[�W���[�̃f�B�N�V���i���[�ɏ㏑����������
        if (_character._isFriend)
        {
            _position = new Vector2[1]{ new Vector2((int)this.transform.localPosition.x / 5, 
                (int)this.transform.localPosition.z / -5) };
        }
        else
        {
            _position = new Vector2[1]{ new Vector2((int)this.transform.localPosition.x / 5 + 4, 
                (int)this.transform.localPosition.z / -5)};
        }
        _battleManager._ObjectPositions[this.gameObject] = _position;
    }
    /// <summary>���g���U���͈͓������ׂ�</summary>
    void UnderAttack(CharacterData character,List<Vector2> _AA,List<Vector2> _AAA)
    {
        foreach (var aa in _AA)
        {
            if(aa.y == _position[0].y && aa.x == _position[0].x)
            {
                Debug.Log("�U���͈͓��I�I�I");
                break;
            }
        }
    }
    /// <summary>�U�����󂯂����̏���</summary>
    void DamageProcess()
    {

    }
}
