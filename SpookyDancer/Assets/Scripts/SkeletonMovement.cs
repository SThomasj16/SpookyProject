using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public Animator animator;
    public Transform target;
    private static readonly int Blend = Animator.StringToHash("Blend");
    void Update()
    {
        var dir = (target.position - transform.position).normalized;
        transform.Translate(dir * Time.deltaTime);
        animator.SetFloat(Blend,dir.x);
    }
}
