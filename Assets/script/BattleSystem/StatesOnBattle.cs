using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>バトル時の一時ステータス </summary>
public class StatesOnBattle : MonoBehaviour
{
    [SerializeField] CharacterData _character;
    int _health;
    int _attack;
    int _diffence;
    int _sp;
    /// <summary>現在の座標</summary>
    int[] _position = new int[2] {0,0};
    /// <summary>計算用攻撃エリア。[マス目の数,x座標,y座標]</summary>
    public int[,,] _areaOnSystem;
    void Start()
    {
        //とりあえず初期値で取得
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
    /// <summary>変換したいスキル番号を受け取ります。</summary>
    public int[] AreaConvert(int _skillNum)
    {
        int _length = 0;
        //_areaOnSystem = new int[_character._skills[_skillNum]._attackArea.Length,8, 5];
        for(int i = 0;i < _character._skills[_skillNum]._attackArea.Length; i++)
        {
            //_attackAreaの数字を座標系に変換　例）場所25→4,4
            _areaOnSystem[i, _character._skills[_skillNum]._attackArea[i] / 5,
                _character._skills[_skillNum]._attackArea[i] % 5] = 1;
            _length = i;
        }
        return new int[] { 1, 1, 1 };
    }
}
