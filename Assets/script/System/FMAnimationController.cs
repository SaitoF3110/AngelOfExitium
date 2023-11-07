using UnityEngine;

public class FMAnimationController : MonoBehaviour
{
    
    void Start()
    {
        Animator _anim = GetComponent<Animator>();
        float random = Random.Range(0.0f, 1.0f);
        _anim.Play("BlackCloudAnim", 0, random);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        float randomColor = Random.Range(0.0f, 1.0f);
        sprite.color = new Color(randomColor, randomColor, randomColor);
    }
}
