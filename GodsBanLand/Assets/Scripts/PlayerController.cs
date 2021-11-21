using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator animator;

    //�ƶ���ֵ
    public float runSpeed;
    public float jumpSpeed;

    //�ж�����Ƿ��ڵ�����
    RaycastHit2D info;
    public float checkDistance;
    public  bool playerIsJump;

    //�����ж�
    GameObject attackZone;
    public float attackTime;
    public float beforeAttackTime;
    public bool hasWeapon;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        animator.SetBool("IsFalling", false);

        attackZone = gameObject.transform.GetChild(0).gameObject;
        attackZone.SetActive(false);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        Attack();

        GroundCheck();

    }


    public void Move()
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

        if (playerIsJump == true && Mathf.Abs(rb.velocity.y) <= 0.005)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.deltaTime);
            animator.SetBool("IsJumping", true);
            animator.SetBool("isNearlyOnGround", false);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
            animator.SetBool("isNearlyOnGround", false);
            playerIsJump = false;
        }
    }

    void Attack()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("IsFiring", true);
            
            //��������ǰҡʱ�� + ������ײ�����ʱ�� + ������ײ����ʧʱ��
            //���Ǻ��ѵ����أ�
            Invoke("BeforeAttack", beforeAttackTime);
            Invoke("Delay", attackTime);
        }

    }

    void GroundCheck()
    {
        RaycastHit2D info = Physics2D.Raycast(transform.position, Vector2.down, checkDistance);

        if (info.collider != null)
        {
            if (info.collider.gameObject.tag == "Ground")
            {
                animator.SetBool("isNearlyOnGround", true);
                animator.SetBool("IsFalling", false);
            }
        }
    }

    public void BeforeAttack()
    {
        attackZone.SetActive(true);
    }

    public void Delay()
    {
        animator.SetBool("IsFiring", false);
        attackZone.SetActive(false);
    }

}
