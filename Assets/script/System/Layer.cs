using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    MeshRenderer textMeshObj;
    public int _layerNum = 0;
    void Start()
    {
        textMeshObj = GetComponent<MeshRenderer>();
        textMeshObj.gameObject.GetComponent<MeshRenderer>().sortingOrder = _layerNum;
    }

}
