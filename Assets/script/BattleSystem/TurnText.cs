using UnityEngine;
using UnityEngine.UI;

public class TurnText : MonoBehaviour, ITurn
{
    public void Friend()
    {
        this.GetComponent<Text>().text = "味方行動選択";
    }
    public void FriendAction()
    {
        this.GetComponent<Text>().text = "味方攻撃";
    }
    public void Enemy()
    {
        this.GetComponent<Text>().text = "敵のターン";
    }
}
