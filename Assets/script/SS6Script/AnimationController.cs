using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GameObject _stay;
    [SerializeField] GameObject _attack1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            foreach (Transform child in this.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Instantiate(_stay,this.transform);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (Transform child in this.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Instantiate(_attack1, this.transform);
        }
    }
}
