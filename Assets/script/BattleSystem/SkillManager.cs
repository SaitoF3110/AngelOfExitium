using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour ,ITurn
{
    [SerializeField] SkillData skillData;
    [SerializeField] GameObject character;
    BattleManager _battleManager;
    Vector2 _skillChara;
    /// <summary>�����X�L���B�e�^�[�����ɏ�����</summary>
    public Dictionary<CharacterData, SkillData> _skills = new Dictionary<CharacterData, SkillData>();//�L�����N�^�[��񂩂���בւ���
    /// <summary>�s�����B���בւ��\�B�e�^�[�����ɏ�����</summary>
    public List<CharacterData> _actOrder = new List<CharacterData>();

    /// <summary>���X�L���f�[�^�A�U���͈́A�U���\�͈́�</summary>
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
        //�f���Q�[�g�o�^
        _battleManager = GameObject.FindObjectOfType<BattleManager>();
        _battleManager.CharaPosition += CharactorArea;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            //�X�L�������ɓo�^���v�Z
            SkillAct(_skillChara,character);
        }
    }
    void CharactorArea(GameObject[] gameObjects, Vector2[][] vector2s) 
    {
        _skillChara = vector2s[Array.IndexOf(gameObjects, character)][0];
    }
    /// <summary>�X�L���̍U���͈͂��v�Z���f���Q�[�g�œn��
    /// �L�����N�^�[�̃X�L���I�����ɌĂяo��</summary>

    /// <param name="posi">�X�L�������҂̈ʒu</param>
    /// <param name="battleObj">�o�g���I�u�W�F�N�g</param>
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
            //���݈ʒu�Ƌ�������U���͈͂��v�Z
            _AA.Add(new Vector2(posi.x + _skills[character]._attackAreas[i].x * _friend, posi.y + _skills[character]._attackAreas[i].y));
            //_AAA.Add(new Vector2(posi.x + _skills[character]._attackAreas[i].x * _friend, posi.y + _skills[character]._attackAreas[i].y));
        }
        //�U���\�͈͂̌v�Z������
        //�G������}�X�ȊO���폜
        foreach(Vector2 position in _AA)
        {
            //BM�̃I�u�W�F�N�g�ʒu�܂Ƃ߂Ɏw��|�W�V��������������ǉ�
            foreach (Vector2[] vector2s in _battleManager._ObjectPositions.Values)
            {
                if (vector2s[0] == position) 
                {
                    _AAA.Add(position);
                }
            }
        }
        //�u�S�̎w��v���I�t�̎�
        if (!_skills[character]._allTarget)
        {
            if (_friend == 1)
            {
                //x�ʒu�����������ɕ��ׂ�
                _AAA.Sort((a, b) => (int)a.x - (int)b.x);
            }
            else
            {
                //x�ʒu���傫�����ɕ��ׂ�
                _AAA.Sort((a, b) => (int)b.x - (int)a.x);
            }
            _AAA.RemoveAll(s => _AAA.IndexOf(s) > _skills[character]._penetratValue);//�ђʂł��镪�����c��
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
