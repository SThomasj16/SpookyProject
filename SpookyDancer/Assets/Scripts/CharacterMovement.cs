using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public LayerMask enemyLayer;
    private static readonly int Attack = Animator.StringToHash("Attack");
    private Animator _animator;
    private bool _isAttacking;
    private SpriteRenderer _spriteRenderer;
    private static readonly int Walk = Animator.StringToHash("Walk");

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        var xValue = Input.GetAxis("Horizontal");
        var yValue = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger(Attack);
            _isAttacking = true;
            var results = Physics2D.OverlapCircleAll(transform.position, 2, enemyLayer);
            foreach (var enemy in results)
            {
                if(!enemy) continue;
                enemy.GetComponent<SkeletonMovement>().TakeDamage();
            }
        }

        if (Input.GetKeyDown(KeyCode.A)) _spriteRenderer.flipX = true;

        if (Input.GetKeyDown(KeyCode.D)) _spriteRenderer.flipX = false;

        if (_isAttacking) return;
        _animator.SetFloat(Walk,  xValue + yValue);
        rigidbody.velocity =  2 *(new Vector3(xValue, yValue));
    }
    public void OnAttackEnds()
    {
        _isAttacking = false;
    }
}
