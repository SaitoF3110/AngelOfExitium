using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillActionController : MonoBehaviour, ITurn
{
    AudioSource _audio;
    [SerializeField] Text _turnText;
    [SerializeField] GameObject _turnFlame;
    [SerializeField] AudioClip _turnSound;
    [SerializeField] AudioClip _decisionSE;
    /// <summary>現在ターン数</summary>
    int _turn = 1;
    public int _iTurn = -1;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        _turnText.text = _turn.ToString();
        Turn();
        if(Input.GetKeyDown(KeyCode.N))
        {
            _turnFlame.transform.DORotate(new Vector3(0,0,90 * _turn + 45), 1f).SetEase(Ease.OutBack);
            _turn++;
            _audio.PlayOneShot(_turnSound);
            _iTurn = 0;
        }
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
    /// <summary>ITurnの制御</summary>
    public void Turn()
    {
        var objects = FindObjectsOfType<GameObject>();
        
        foreach (var obj in objects)
        {
            //とりあえずテキトー
            //後で必要になった時修正
            ITurn i = obj.GetComponent<ITurn>();
            
            if (_iTurn == 0)
            {
                i?.Friend();
            }
            else if (_iTurn == 1)
            {
                i?.FriendAction();
            }
            else if (_iTurn == 2)
            {
                i?.Enemy();
            }
            else if (_iTurn == 3)
            {
                i?.EnemyAction();
            }
            if (_iTurn == -1)
            {
                i?.Friend();
            }
        }
        if (_iTurn == -1)
        {
            _iTurn = 0;
        }
    }
    public void Decision()
    {
        if( _iTurn == 0)
        {
            _iTurn = 1;
            _audio.PlayOneShot(_decisionSE);
        }
    }
}
