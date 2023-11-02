using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>キャラクターごとのバトル時の一時ステータス </summary>
public class StatesOnBattle : MonoBehaviour
{
    [SerializeField] CharacterData _character;
    int _health;
    int _attack;
    int _diffence;
    int _sp;
    SkillManager _skillData;
    BattleManager _battleManager;
    /// <summary>現在の座標</summary>
    Vector2[] _position = new Vector2[1] {new Vector2(1,1)};
    /// <summary>計算用攻撃エリア。[マス目の数,x座標,y座標]</summary>
    public int[,,] _areaOnSystem;

    void Start()
    {
        //とりあえず初期値で取得
        //装備、バフデバフの処理は後ほど
        _attack = _character._defaultAttack;
        _diffence = _character._defaultDiffence;
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
    void UnderAttack(CharacterData character,List<Vector2> _AA,List<Vector2> _AAA)
    {
        foreach (var aa in _AA)
        {
            if(aa.y == _position[0].y && aa.x == _position[0].x)
            {
                Debug.Log("攻撃範囲内！！！");
                break;
            }
        }
    }
    /// <summary>攻撃を受けた時の処理</summary>
    void DamageProcess()
    {

    }
}
