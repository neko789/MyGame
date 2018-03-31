using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeController : MonoBehaviour
{
    Animator animator;
    private float ground = -3.5f;
    private Vector2 posi;
    Rigidbody2D ri2d;
    private bool goal;
    private float m;
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.ri2d = GetComponent<Rigidbody2D>();
        m = 1;
    }

    void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool isGround = (transform.position.y > this.ground) ? false : true;
        this.animator.SetBool("isGround", isGround);

        if (Input.GetMouseButtonDown(0))
        {
            m = m*1.8f;
            if (pos.x >= this.transform.position.x && transform.localScale.x < 0)
            {
                //this.animator.SetFloat("Horizontal", 1);
                SwitchScale();
            }
            else if (pos.x < this.transform.position.x && transform.localScale.x > 0)
            {
                //this.animator.SetFloat("Horizontal", -1);
                SwitchScale();
            }
            posi = pos;
            goal = true;
        }
    }
    void FixedUpdate()
    {
        if (goal)
        {
            if (posi.x > this.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.right * m;
                goal = false;
            }
            else if (posi.x < this.transform.position.x)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.left * m;
                goal = false;

            }
        }
    }
    void SwitchScale()
    {
        Vector3 scale = transform.localScale;
        scale.x = -1 * scale.x;
        transform.localScale = scale;
        m = 1;
    }
}