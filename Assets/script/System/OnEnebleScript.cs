using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnebleScript : MonoBehaviour
{
    [SerializeField] GameObject[] _activeObj;
    Vector2 _width = new Vector2(0,1000);
    bool _enabled = false;
    private void OnEnable()
    {
        _enabled = true;
    }
    private void OnDisable()
    {
        _enabled = false;
        _width.x = 0;
    }
    private void Update()
    {
        if (_enabled && _width.x < 1000)
        {
            _width.x += 10;
            GetComponent<RectTransform>().sizeDelta = _width;
        }
        if(_width.x >= 1000)
        {
            foreach (var obj in _activeObj)
            {
                obj.SetActive(true);
            }
        }
    }
}
