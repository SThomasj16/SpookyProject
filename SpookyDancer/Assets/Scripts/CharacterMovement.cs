using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody2D rigidbody;
    public LayerMask enemyLayer;
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

           var _results = Physics2D.OverlapCircleAll(transform.position, 2, enemyLayer);
            foreach (var enemy in _results)
            {
                if(!enemy) continue;
                enemy.GetComponent<SkeletonMovement>().TakeDamage();
            }
        }
        if(!isAttacking)
        {
            Animator.SetFloat(Blend,xValue);
            rigidbody.velocity =  2 *(new Vector3(xValue,yValue));
        }
    }
    public void OnAttackEnds()
    {
        isAttacking = false;
    }
}
