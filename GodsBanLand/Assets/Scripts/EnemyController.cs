using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    Animator animator;
    float dist;
    public float awakeDist;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float dist = Vector3.Distance(target.transform.position, transform.position);
            //print("Distance to other:" + dist);

            if (dist <= awakeDist)
            {
                animator.SetBool("IsAwaking", true);
            }
            else
            {
                animator.SetBool("IsAwaking", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Attack")
        {
            Debug.Log("hit!");
            Hit();
        }
    }

    public void Hit()
    {
        Destroy(gameObject, 0.1f);
    }
}
