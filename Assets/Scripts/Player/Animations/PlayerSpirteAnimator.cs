using System.Collections;
using UnityEngine;

public class PlayerSpirteAnimator : MonoBehaviour
{

    public Animator MyAnimator;
    public SpriteRenderer MySprite;

    private void Awake()
    {
        MyAnimator = GetComponent<Animator>();
        MySprite = GetComponent<SpriteRenderer>();
    }

    public void RunMeleeAnim()
    {
        MyAnimator.SetTrigger("MeleeAttack");
    }

    public void TakeDamageAnim()
    {
        MyAnimator.SetTrigger("TakeDamage");
    }

    public void JumpingAnim(bool Jumping)
    {
        MyAnimator.SetBool("Jumping", Jumping);
    }

    public void MovingAnim(Vector2 Speed)
    {
        MyAnimator.SetFloat("MovementX", Speed.x);
        MyAnimator.SetFloat("MovementY", Speed.y);
    }
}
