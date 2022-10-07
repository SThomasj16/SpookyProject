using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xValue = Input.GetAxis("Horizontal");
        var yValue = Input.GetAxis("Vertical");
        Animator.SetFloat("Blend",xValue);
        transform.position +=  Time.deltaTime * 2 *(new Vector3(xValue,yValue)); 
    }
}
