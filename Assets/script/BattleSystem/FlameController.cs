using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    [SerializeField] bool _isEnemy;
    [SerializeField] int _y;
    [SerializeField] Color _color;
    Color _defaultColor;
    public Vector2 _position;
    SkillManager _skillData;
    BattleManager _battleManager;
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
        _defaultColor = _sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _sr.color = _defaultColor;
        }
    }
    void CharactorArea(GameObject[] gameObjects, Vector2[][] vector2s)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (vector2s[i][0].x == _position.x && vector2s[i][0].y == _position.y)
            {
                _sr.color = Color.blue;
                break;
            }
        }
    }
    void AttackArea(CharacterData character, List<Vector2> _AA, List<Vector2> _AAA)
    {
        foreach (var aa in _AA)
        {
            if (aa.y == _position.y && aa.x == _position.x)
            {
                _sr.color = _color;
                break;
            }
        }
    }
}
