using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody;
    public int force; 
    public int speed;
    public Transform target;
    private static readonly int Blend = Animator.StringToHash("Blend");
    private static readonly int Hurts = Animator.StringToHash("Hurts");
    private Vector3 _dir;
    private bool _stun;

    void Update()
    {
        if(_stun)return;
        _dir = (target.position - transform.position).normalized;
        rigidbody.velocity = (_dir * speed);
        var animationDir = Mathf.Clamp(target.position.x - transform.position.x, -1, 1);
        animator.SetFloat(Blend,animationDir);
    }

    public void OnStunEnds()
    {
        _stun = false;
    }

    public void TakeDamage()
    {
        animator.SetTrigger(Hurts);
        rigidbody.AddForce( _dir * -force , ForceMode2D.Force);
        _stun = true;
    }
}
