using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorDrag : MonoBehaviour
{
    [SerializeField] GameObject _manager;
    [SerializeField] Transform _transform;
    [SerializeField] Transform _transform2;
    [SerializeField] float x = 10, z = 10;
    InGameUI _gameUI;
    Vector3 moveTo;
    Vector3 _MousePosiOnClick;
    bool _Pressed = false;
    public GameObject clickedGameObject;
    FlameController _controller;
    void Start()
    {
        _gameUI = _manager.GetComponent<InGameUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(Input.mousePosition);
            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
            }

            Debug.Log(clickedGameObject);
            if (clickedGameObject != null)
            {
                if (clickedGameObject.tag == "Flame")
                {
                    _controller = clickedGameObject.GetComponent<FlameController>();
                    this.transform.localPosition = new Vector3(_controller._position.x * 5,0,
                        _controller._position.y * -5);
                }
            }
        }
    }
    void Botsu()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _Pressed = false;
        }
        if (_gameUI != null)
        {
            if (_gameUI.clickedGameObject == this.gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _MousePosiOnClick = Input.mousePosition;
                    _Pressed = true;

                }
            }
        }
        if (_Pressed)
        {
            //this.transform.position -= new Vector3((_MousePosiOnClick.x - mousePos.x) / 1000, 0, (_MousePosiOnClick.y - mousePos.y) / 1000);
            Vector3 mousePos = Input.mousePosition;

            moveTo = Camera.main.ScreenToWorldPoint(_transform.position - _transform2.position - mousePos);
            moveTo.y = 0;
            moveTo.x += mousePos.y / 600;
            moveTo.x *= x;
            moveTo.x += -12;
            moveTo.z += mousePos.y / Screen.height * z;
            transform.localPosition = moveTo;
        }
    }
}
