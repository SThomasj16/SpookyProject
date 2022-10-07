using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator Animator;
    private static readonly int Blend = Animator.StringToHash("Blend");
    private static readonly int Atrack = Animator.StringToHash("Attack");
    private bool isAttacking;

    void Start()
    {
        
    }

    void Update()
    {
        var xValue = Input.GetAxis("Horizontal");
        var yValue = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetTrigger(Atrack);
            isAttacking = true;
        }
        if(!isAttacking)
        {
            Animator.SetFloat(Blend,xValue);
            transform.position +=  Time.deltaTime * 2 *(new Vector3(xValue,yValue));
        }
    }
    public void OnAttackEnds()
    {
        isAttacking = false;
    }
}
