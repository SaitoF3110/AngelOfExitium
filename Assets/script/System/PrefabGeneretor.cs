using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGeneretor : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BottunGeneretor()
    {
        Instantiate( _prefab );
    }
}
