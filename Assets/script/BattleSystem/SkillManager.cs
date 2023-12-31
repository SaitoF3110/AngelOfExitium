using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour ,ITurn
{
    [SerializeField] SkillData skillData;
    [SerializeField] GameObject character;
    BattleManager _battleManager;
    Vector2 _skillChara;
    /// <summary>発動スキル。各ターン毎に初期化</summary>
    public Dictionary<CharacterData, SkillData> _skills = new Dictionary<CharacterData, SkillData>();//キャラクター情報から並べ替える
    /// <summary>行動順。並べ替え可能。各ターン毎に初期化</summary>
    public List<CharacterData> _actOrder = new List<CharacterData>();

    /// <summary>＜スキルデータ、攻撃範囲、攻撃可能範囲＞</summary>
    event Action<GameObject, List<Vector2>, List<Vector2>> _skillArea;
    public Action<GameObject, List<Vector2>, List<Vector2>> SkillArea
    {
        get { return _skillArea; }
        set { _skillArea = value; }
    }
    void Start()
    {
        StatesOnBattle _states = character.GetComponent<StatesOnBattle>();
        _skills.Add(_states._character, skillData);
        //デリゲート登録
        _battleManager = GameObject.FindObjectOfType<BattleManager>();
        _battleManager.CharaPosition += CharactorArea;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //スキル辞書に登録→計算
            SkillAct(_skillChara,character);
        }
    }
    void CharactorArea(GameObject[] gameObjects, Vector2[][] vector2s) 
    {
        _skillChara = vector2s[Array.IndexOf(gameObjects, character)][0];
    }
    /// <summary>スキルの攻撃範囲を計算→デリゲートで渡す
    /// キャラクターのスキル選択時に呼び出し</summary>

    /// <param name="posi">スキル発動者の位置</param>
    /// <param name="battleObj">バトルオブジェクト</param>
    void SkillAct(Vector2 posi,GameObject battleObj)
    {
        StatesOnBattle states = battleObj.GetComponent<StatesOnBattle>();
        CharacterData character = states._character;
        /// <summary>Attack Area</summary>
        List<Vector2> _AA = new List<Vector2>();
        /// <summary>AttackAble Area</summary>
        List<Vector2> _AAA = new List<Vector2>();
        int _friend = 1;
        if(!character._isFriend)
        {
            _friend = -1;
        }
        for(int i = 0;i < _skills[character]._attackAreas.Length; i++)
        {
            //現在位置と距離から攻撃範囲を計算
            _AA.Add(new Vector2(posi.x + _skills[character]._attackAreas[i].x * _friend, posi.y + _skills[character]._attackAreas[i].y));
            //_AAA.Add(new Vector2(posi.x + _skills[character]._attackAreas[i].x * _friend, posi.y + _skills[character]._attackAreas[i].y));
        }
        //攻撃可能範囲の計算↓↓↓
        //敵がいるマス以外を削除
        foreach(Vector2 position in _AA)
        {
            //BMのオブジェクト位置まとめに指定ポジションがあったら追加
            foreach (Vector2[] vector2s in _battleManager._ObjectPositions.Values)
            {
                if (vector2s[0] == position) 
                {
                    _AAA.Add(position);
                }
            }
        }
        //「全体指定」がオフの時
        if (!_skills[character]._allTarget)
        {
            if (_friend == 1)
            {
                //x位置が小さい順に並べる
                _AAA.Sort((a, b) => (int)a.x - (int)b.x);
            }
            else
            {
                //x位置が大きい順に並べる
                _AAA.Sort((a, b) => (int)b.x - (int)a.x);
            }
            _AAA.RemoveAll(s => _AAA.IndexOf(s) > _skills[character]._penetratValue);//貫通できる分だけ残す
        }
        _skillArea(battleObj, _AA, _AAA);
    }
    public void Friend()
    {

    }
    public void FriendAction()
    {

    }
    public void Enemy()
    {

    }
    public void EnemyAction()
    {

    }
}
