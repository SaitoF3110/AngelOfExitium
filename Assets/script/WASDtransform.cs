using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDtransform : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cam; //Main CameraのCamera
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>(); //Main CameraのCameraを取得する。
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 1f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -1f, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(1f, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            cam.orthographicSize = cam.orthographicSize - 1.0f; //ズームイン。
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            cam.orthographicSize = cam.orthographicSize + 1.0f; //ズームアウト。
        }
    }
}
