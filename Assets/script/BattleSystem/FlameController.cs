using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    public bool _isEnemy;
    [SerializeField] int _y;
    public GameObject _battleObject;
    public Vector2 _position;
    SkillManager _skillData;
    BattleManager _battleManager;
    BattleFlameManager _bfm;
    SpriteRenderer _sr;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        //é©êgÇÃà íuÇåvéZ
        if (_isEnemy)
        {
            _position = new Vector2((int)this.transform.localPosition.x / 5 + 4,_y);
        }
        else
        {
            _position = new Vector2((int)this.transform.localPosition.x / 5, _y);
        }
        //ÉfÉäÉQÅ[ÉgÇÃìoò^
        _skillData = GameObject.FindObjectOfType<SkillManager>();
        _skillData.SkillArea += AttackArea;
        _battleManager = GameObject.FindObjectOfType<BattleManager>();
        _battleManager.CharaPosition += CharactorArea;
        _bfm = GameObject.FindObjectOfType<BattleFlameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _sr.color = _bfm._default;
        }
    }
    void CharactorArea(GameObject[] gameObjects, Vector2[][] vector2s)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (vector2s[i][0].x == _position.x && vector2s[i][0].y == _position.y)
            {
                _battleObject = gameObjects[i];
                //_sr.color = _bfm._friend;
                break;
            }
            if(i == gameObjects.Length - 1)
            {
                _battleObject = null;
            }
        }
    }
    void AttackArea(GameObject character, List<Vector2> _AA, List<Vector2> _AAA)
    {
        foreach (var aa in _AA)
        {
            if (aa.y == _position.y && aa.x == _position.x)
            {
                _sr.color = _bfm._AA;
                break;
            }
        }
        foreach (var aaa in _AAA)
        {
            if (aaa.y == _position.y && aaa.x == _position.x)
            {
                _sr.color = _bfm._AAA;
                break;
            }
        }
    }
}
