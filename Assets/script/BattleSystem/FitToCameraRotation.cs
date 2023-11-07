using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitToCameraRotation : MonoBehaviour
{
    GameObject _camera;
    void Start()
    {
        _camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(_camera != null)
        {
            var rotate = _camera.transform.rotation;
            rotate.y = 0;
            rotate.z = 0;
            this.transform.rotation = rotate;
        }
    }
}
