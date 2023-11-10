using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class CommandController : MonoBehaviour
{
    [SerializeField] GameObject _camera;
    CharactorDrag _drag;
    bool _selected = false;
    Vector3 _defaultCameraPosi;
    float _defaultCameraRX;
    void Start()
    {
        //ÉfÉäÉQÅ[ÉgÇ…ìoò^
        _drag = GetComponent<CharactorDrag>();
        _drag.ClickedGameObject += BattleGameObject;
        _defaultCameraPosi = _camera.transform.position;
        _defaultCameraRX = _camera.transform.rotation.eulerAngles.x;
    }

    void Update()
    {
        
    }
    void BattleGameObject(GameObject clickedObj)
    {
        Debug.Log(this.gameObject.name);
        if(_camera != null && !_selected)
        {
            //_camera.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y + 10, this.transform.position.z + 11);
            _camera.transform.DOMove(new Vector3(this.transform.position.x + 1, this.transform.position.y + 10, this.transform.position.z + 11), 0.3f).SetEase(Ease.OutQuint);
            //_camera.transform.eulerAngles += new Vector3(20,0,0);
            _camera.transform.DORotate(Vector3.left * -51f, 0.3f).SetEase(Ease.OutQuint);
        }
        if(_selected)
        {
            _camera.transform.DOMove(new Vector3(_defaultCameraPosi.x,_defaultCameraPosi.y,_defaultCameraPosi.z), 0.3f).SetEase(Ease.OutQuint);
            _camera.transform.DORotate(Vector3.left * -_defaultCameraRX, 0.3f).SetEase(Ease.OutQuint);
        }
        _selected = !_selected;
    }
}
