using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveWithSpeed(float movement)
    {
        
        if (animator != null)
        {
            //movement = Mathf.Abs(movement);
            Debug.Log("Speed :"+ movement);
            animator.SetFloat("SpeedX", movement);
            animator.SetBool("OnMovement", true);
        }
    }

    public void setIdle()
    {
        animator.SetFloat("SpeedX", 0.0f);
        animator.SetBool("OnMovement", false);
    }
}
