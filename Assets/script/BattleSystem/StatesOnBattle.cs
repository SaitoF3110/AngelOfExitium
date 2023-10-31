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
    /// <summary>現在の座標</summary>
    Vector2 _position = new Vector2(0,0);
    /// <summary>計算用攻撃エリア。[マス目の数,x座標,y座標]</summary>
    public int[,,] _areaOnSystem;
    void Start()
    {
        //とりあえず初期値で取得
        //装備、バフデバフの処理は後ほど
        _attack = _character._defaultAttack;
        _diffence = _character._defaultDiffence;
        //初期位置の処理もここに
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
