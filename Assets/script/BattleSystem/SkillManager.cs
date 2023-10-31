using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SkillManager : MonoBehaviour
{
    /// <summary>�����X�L���B�e�^�[�����ɏ�����</summary>
    SkillData[] skills;

    /// <summary>���X�L���f�[�^�A�U���͈́A�U���\�͈́�</summary>
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
    /// <summary>�X�L���̍U���͈͂��v�Z���f���Q�[�g�œn��
    /// �L�����N�^�[�̃X�L���I�����ɌĂяo��</summary>

    /// <param name="posi">�X�L�������҂̈ʒu</param>
    /// <param name="skill">�X�L���f�[�^</param>
    void SkillAct(Vector2 posi,SkillData skill)
    {
        List<Vector2> _AA = new List<Vector2>();
        List<Vector2> _AAA = new List<Vector2>();
        for(int i = 0;i < skill._attackAreas.Length; i++)
        {
            //���݈ʒu�Ƌ�������U���͈͂��v�Z
            _AA.Add(new Vector2(posi.x + skill._attackAreas[i].x, posi.y + skill._attackAreas[i].y));
            _AAA.Add(new Vector2(posi.x + skill._attackAreas[i].x, posi.y + skill._attackAreas[i].y));
        }
        //�U���\�͈͂̌v�Z������
        if(skill._range != 0 || skill._range != 99)
        {
            //x�ʒu�����������ɕ��ׂ�
            _AAA.Sort((a, b) => (int)a.x - (int)b.x);
            //Y���W�������}�X�ȊO���폜
            _AAA.RemoveAll(s => posi.y != s.y);
            //�ŏ��̐��}�X�ȊO���폜
            _AAA.RemoveAll(s => _AAA.IndexOf(s) > skill._penetratValue);//�ђʂł��镪�����c��
            _skillArea(skill, _AA, _AAA);
        }
    }
}
