using UnityEngine;
using UnityEngine.UI;

public class TurnText : MonoBehaviour, ITurn
{
    public void Friend()
    {
        this.GetComponent<Text>().text = "�����s���I��";
    }
    public void FriendAction()
    {
        this.GetComponent<Text>().text = "�����U��";
    }
    public void Enemy()
    {
        this.GetComponent<Text>().text = "�G�̃^�[��";
    }
}
