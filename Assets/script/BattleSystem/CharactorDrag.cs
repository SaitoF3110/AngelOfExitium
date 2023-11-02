using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharactorDrag : MonoBehaviour
{
    public GameObject dragGameObject;
    public GameObject clickGameObject;
    FlameController _controller;
    FlameController _dragController;
    bool _isDragging = false;
    Vector3 _mouseDown;
    Vector3 _mouseMove;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseDown = Input.mousePosition;//クリック時の座標取得
            //Rayによるマウス当たり判定
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickGameObject = hit.collider.gameObject;
            }
        }
        if (Input.GetMouseButton(0))
        {
            //Rayによるマウス当たり判定
            dragGameObject = null;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                dragGameObject = hit.collider.gameObject;
            }
            _mouseMove = Input.mousePosition;//現在のマウスの座標取得
            Vector3 distance = _mouseDown - _mouseMove;//距離
            if (dragGameObject != null)
            {
                if (dragGameObject.tag == "Flame")
                {
                    _controller = clickGameObject.GetComponent<FlameController>();
                    _dragController = dragGameObject.GetComponent<FlameController>();
                    //マウスをドラッグして、かつ、バトルオブジェクトがあったらtrueに
                    if (distance.x * distance.x > 100 && _controller._battleObject == this.gameObject || distance.y * distance.y > 100 && _controller._battleObject == this.gameObject)
                    {
                        _isDragging = true;
                    }
                    if(!_dragController._isEnemy && _isDragging)
                    {
                        this.transform.localPosition = new Vector3(_dragController._position.x * 5, 0,
                             _dragController._position.y * -5);
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }
    }
    void MouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseDown = Input.mousePosition;//クリック時の座標取得

        }
        if (Input.GetMouseButton(0))
        {

        }
    }
}
