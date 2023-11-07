using UnityEngine;
using UnityEngine.UI;

public class TurnText : MonoBehaviour, ITurn
{
    public void Friend()
    {
        this.GetComponent<Text>().text = "–¡•ûs“®‘I‘ğ";
    }
    public void FriendAction()
    {
        this.GetComponent<Text>().text = "–¡•ûUŒ‚";
    }
    public void Enemy()
    {
        this.GetComponent<Text>().text = "“Gs“®‘I‘ğ";
    }
    public void EnemyAction()
    {
        this.GetComponent<Text>().text = "“GUŒ‚";
    }
}
