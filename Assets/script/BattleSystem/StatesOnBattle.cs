using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>�L�����N�^�[���Ƃ̃o�g�����̈ꎞ�X�e�[�^�X </summary>
public class StatesOnBattle : MonoBehaviour
{
    public CharacterData _character;
    public int _maxHealth;
    public int _health;
    public int _maxSp;
    public int _sp;
    //����Attack��Diffence�͈�̐퓬���s��
    //�o�t�f�o�t�͍U�����莞�Ɍv�Z
    public int _attack;
    public int _diffence;
    SkillManager _skillData;
    BattleManager _battleManager;
    /// <summary>���݂̍��W</summary>
    Vector2[] _position = new Vector2[1] {new Vector2(1,1)};
    /// <summary>�v�Z�p�U���G���A�B[�}�X�ڂ̐�,x���W,y���W]</summary>
    public int[,,] _areaOnSystem;
    //���ݏ������Ă���o�t�f�o�t��
    List<EffectEnum.Effect> _effects = new List<EffectEnum.Effect>();

    void Start()
    {
        //�Ƃ肠���������l�Ŏ擾
        //�����A�o�t�f�o�t�̏����͌�ق�
        _attack = _character._defaultAttack;
        _diffence = _character._defaultDiffence;
        _health = _character._defaultHealth;
        _maxHealth = _character._defaultHealth;
        _sp = _character._defaultSp;
        _maxSp = _character._defaultSp;
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
    void UnderAttack(GameObject battleObj,List<Vector2> _AA,List<Vector2> _AAA)
    {
        foreach (var aa in _AA)
        {
            if(aa.y == _position[0].y && aa.x == _position[0].x)
            {
                StatesOnBattle states = battleObj.GetComponent<StatesOnBattle>();
                CharacterData character = states._character;
                StatesOnBattle _states = battleObj.GetComponent<StatesOnBattle>();

                DamageProcess(_states, _skillData._skills[character]);
                break;
            }
        }
    }
    /// <summary>�U�����󂯂����̏���</summary>
    void DamageProcess(StatesOnBattle _states,SkillData skill)
    {
        float skillDamage = skill._hpDamage;
        float damage = skillDamage / 100 * _states._attack - _diffence;
        //�Œ�ۏ�_���[�W�@���x�����Ƃɕϓ�
        if(damage <= 1)
        {
            damage = 1;
        }
        _health -= (int)damage;
    }
}
