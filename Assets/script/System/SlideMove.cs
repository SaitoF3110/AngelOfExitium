using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMove : MonoBehaviour
{
    [SerializeField] float _moveTime = 1;
    [SerializeField] float _setValue = 400;
    [SerializeField] float _audioTime = 0;
    Vector3 _default;
    RectTransform obj;
    AudioSource _audio;
    float _timer;
    bool _audioON = false;
    private void Awake()
    {
        obj = this.GetComponent<RectTransform>();
        _audio = obj.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        _audioON = true;
        _default = this.transform.position;
        float _wid = Screen.width;
        if(_wid < 400)
        {
            _wid = 400;
        }
        this.transform.position -= new Vector3(_setValue * (_wid/ 400), 0, 0);
        //デフォルトの位置に動く
        this.transform.DOMove(_default, _moveTime).SetEase(Ease.OutBounce);
        //obj.DOMove(new Vector3(_default.x / Screen.width,(_default.y + _hight) / Screen.height,_default.z), _moveTime).SetEase(Ease.OutBounce);
    }

    // Update is called once per frame
    void Update()
    {
        if(_audio != null && _audioON)
        {
            _timer += Time.deltaTime;
            if(_timer > _audioTime)
            {
                _audio.Play();
                _audioON = false;
                _timer = 0;
            }
        }
    }

}
