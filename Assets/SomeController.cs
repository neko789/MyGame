using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeController : MonoBehaviour
{
    Animator animator;
    private float ground = -3.5f;
    private Vector2 posi;
    Rigidbody2D ri2d;
    private int goal;
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.ri2d = GetComponent<Rigidbody2D>();
        goal = 0;
    }

    void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool isGround = (transform.position.y > this.ground) ? false : true;
        this.animator.SetBool("isGround", isGround);

        if (Input.GetMouseButtonDown(0))
        {
            if (pos.x >= this.transform.position.x && transform.localScale.x < 0)
            {
                //this.animator.SetFloat("Horizontal", 1);
                SwitchScale();
                goal = 1;
                ri2d.AddForce(Vector2.right * 300f);
            }
            else if (pos.x <= this.transform.position.x && transform.localScale.x > 0)
            {
                //this.animator.SetFloat("Horizontal", -1);
                SwitchScale();
                goal = -1;
                ri2d.AddForce(Vector2.left * 300f);
            }
            posi = pos;
        }
    }
    void FixedUpdate()
    {
        if (posi.x > this.transform.position.x && goal > 0)
        {
            ri2d.AddForce(Vector2.right * 40f);

        }
        else if (posi.x < this.transform.position.x && goal < 0)
        {
            ri2d.AddForce(Vector2.left * 40f);

        }
    }
    void SwitchScale()
    {
        Vector3 scale = transform.localScale;
        scale.x = -1 * scale.x;
        transform.localScale = scale;
    }
}