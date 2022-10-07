using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator Animator;
    private static readonly int Blend = Animator.StringToHash("Blend");

    void Start()
    {
        
    }

    void Update()
    {
        var xValue = Input.GetAxis("Horizontal");
        var yValue = Input.GetAxis("Vertical");
        Animator.SetFloat(Blend,xValue);
        transform.position +=  Time.deltaTime * 2 *(new Vector3(xValue,yValue)); 
    }
}
