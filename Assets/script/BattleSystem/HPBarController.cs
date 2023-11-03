using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarController : MonoBehaviour
{
    [SerializeField] bool _isSp = false;
    GameObject _ppObj;
    StatesOnBattle _states;
    
    void Start()
    {
        //親の親にあるキャラデータ取得
        _ppObj = transform.parent.parent.parent.gameObject;
        if (_ppObj != null)
        {
            _states = _ppObj.GetComponent<StatesOnBattle>();
        }
    }
    void Update()
    {
        if(_isSp)
        {
            float _sp = _states._sp;
            float _maxSp = _states._maxSp;
            if (_maxSp != 0)
                this.transform.localPosition = new Vector3(_sp / _maxSp - 1.0f, 0, 0);
        }
        else
        {
            float _health = _states._health;
            float _maxHealth = _states._maxHealth;
            if (_maxHealth != 0)
                this.transform.localPosition = new Vector3(_health / _maxHealth - 1.0f, 0, 0);
        }
    }
}
