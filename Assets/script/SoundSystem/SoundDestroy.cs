using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroy : MonoBehaviour
{
    [SerializeField] float _destroyTime = 1.0f;
    float _timer;
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _destroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
