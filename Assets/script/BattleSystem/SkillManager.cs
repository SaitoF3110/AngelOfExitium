using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SkillManager : MonoBehaviour
{
    /// <summary>発動スキル。各ターン毎に初期化</summary>
    SkillData[] skills;

    /// <summary>＜スキルデータ、攻撃範囲、攻撃可能範囲＞</summary>
    event Action<SkillData, List<Vector2>, List<Vector2>> _skillArea;
    public Action<SkillData, List<Vector2>, List<Vector2>> SkillArea
    {
        get { return _skillArea; }
        set { _skillArea = value; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>スキルの攻撃範囲を計算→デリゲートで渡す
    /// キャラクターのスキル選択時に呼び出し</summary>

    /// <param name="posi">スキル発動者の位置</param>
    /// <param name="skill">スキルデータ</param>
    void SkillAct(Vector2 posi,SkillData skill)
    {
        List<Vector2> _AA = new List<Vector2>();
        List<Vector2> _AAA = new List<Vector2>();
        for(int i = 0;i < skill._attackAreas.Length; i++)
        {
            //現在位置と距離から攻撃範囲を計算
            _AA.Add(new Vector2(posi.x + skill._attackAreas[i].x, posi.y + skill._attackAreas[i].y));
            _AAA.Add(new Vector2(posi.x + skill._attackAreas[i].x, posi.y + skill._attackAreas[i].y));
        }
        //攻撃可能範囲の計算↓↓↓
        if(skill._range != 0 || skill._range != 99)
        {
            //x位置が小さい順に並べる
            _AAA.Sort((a, b) => (int)a.x - (int)b.x);
            //Y座標が同じマス以外を削除
            _AAA.RemoveAll(s => posi.y != s.y);
            //最初の数マス以外を削除
            _AAA.RemoveAll(s => _AAA.IndexOf(s) > skill._penetratValue);//貫通できる分だけ残す
            _skillArea(skill, _AA, _AAA);
        }
    }
}
