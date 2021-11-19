using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator animator;

    public float runSpeed;
    public float jumpSpeed;
    public float attackTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Attack();
    }


    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float facedir = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            rb.velocity = new Vector2(horizontal * runSpeed * Time.deltaTime, rb.velocity.y);
            animator.SetFloat("running", Mathf.Abs(facedir));
        }

        if (facedir != 0)
        {
            rb.transform.localScale = new Vector3(facedir * 8, 8, 0);
        }

        if (Input.GetButton("Jump") && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.deltaTime);
            animator.SetBool("IsJumping", true);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
    }

    void Attack()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("IsFiring", true);
            Invoke("delay", attackTime);
        }

    }

    public void delay()
    {
        animator.SetBool("IsFiring", false);
    }

}
