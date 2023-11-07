using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>キャラクターごとのバトル時の一時ステータス </summary>
public class StatesOnBattle : MonoBehaviour
{
    public CharacterData _character;
    public int _maxHealth;
    public int _health;
    public int _maxSp;
    public int _sp;
    //このAttackとDiffenceは一つの戦闘中不変
    //バフデバフは攻撃判定時に計算
    public int _attack;
    public int _diffence;
    SkillManager _skillData;
    BattleManager _battleManager;
    /// <summary>現在の座標</summary>
    Vector2[] _position = new Vector2[1] {new Vector2(1,1)};
    /// <summary>計算用攻撃エリア。[マス目の数,x座標,y座標]</summary>
    public int[,,] _areaOnSystem;
    //現在所持しているバフデバフ↓
    List<EffectEnum.Effect> _effects = new List<EffectEnum.Effect>();

    void Start()
    {
        //とりあえず初期値で取得
        //装備、バフデバフの処理は後ほど
        _attack = _character._defaultAttack;
        _diffence = _character._defaultDiffence;
        _health = _character._defaultHealth;
        _maxHealth = _character._defaultHealth;
        _sp = _character._defaultSp;
        _maxSp = _character._defaultSp;
        //初期位置の処理もここに

        //デリゲートの登録
        _skillData = GameObject.FindObjectOfType<SkillManager>();
        _skillData.SkillArea += UnderAttack;
        _position[0] = new Vector2(-1,-1);

        _battleManager = GameObject.FindObjectOfType<BattleManager>();
        //自身の位置を登録
        _battleManager._ObjectPositions.Add(this.gameObject, _position);
    }

    void Update()
    {
        //自身の位置をマネージャーのディクショナリーに上書きし続ける
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
    /// <summary>自身が攻撃範囲内か調べる</summary>
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
    /// <summary>攻撃を受けた時の処理</summary>
    void DamageProcess(StatesOnBattle _states,SkillData skill)
    {
        float skillDamage = skill._hpDamage;
        float damage = skillDamage / 100 * _states._attack - _diffence;
        //最低保障ダメージ　レベルごとに変動
        if(damage <= 1)
        {
            damage = 1;
        }
        _health -= (int)damage;
    }
}
