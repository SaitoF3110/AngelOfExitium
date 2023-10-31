using UnityEngine;
/// <summary>ITurnÇÃêßå‰</summary>
public class TurnInterface : MonoBehaviour
{
    void Turn()
    {
        var objects = FindObjectsOfType<GameObject>();
        foreach (var obj in objects)
        {
            ITurn i = obj.GetComponent<ITurn>();
            if (1 + 1 == 0)
            {
                i?.Friend();
            }
            else if (1 == 1)
            {
                i?.Enemy();
            }
        }
    }
}
