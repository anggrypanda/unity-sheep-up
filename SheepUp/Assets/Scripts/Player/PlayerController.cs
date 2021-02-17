using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementForce = 0.5f, jumpForce = 0.15f, jumpTime = 0.3f;

    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("isJumping", true);
            Jump(true);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("isJumping", true);
            Jump(false);
        }
        else
            anim.SetBool("isJumping", false);
    }

    void Jump(bool left)
    {
        SoundManager.instance.JumpSound();

        if (left)
        {
            transform.DORotate(new Vector3(0f, -90f, 0f), 0f);   // Where we want to rotate, duration of the rotation

            rb.DOJump(new Vector3(transform.position.x - movementForce, transform.position.y + jumpForce, transform.position.z),    // Where we want to jump
                     0.5f,                                                                                                          // Jump power
                     1,                                                                                                             // Number of jumps
                     jumpTime);                                                                                                     // Duration of the jump
        }
        else
        {
            transform.DORotate(new Vector3(0f, 0f, 0f), 0f);

            rb.DOJump(new Vector3(transform.position.x, transform.position.y + jumpForce, transform.position.z + movementForce),
                     0.5f,                                                                                                          
                     1,                                                                                                             
                     jumpTime);                                                                                                     
        }
    }
}
