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
        var animationDir = Mathf.Clamp(target.position.x - transform.position.x, -1, 1);
        animator.SetFloat(Blend,animationDir);
    }
}
