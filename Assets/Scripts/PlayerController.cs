using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    public GameObject map;

    public float speed;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.M))
        {
            if(map.activeInHierarchy == false)
            {
                map.SetActive(true);
            }
            else if(map.activeInHierarchy == true)
            {
                map.SetActive(false);
            }
        }



        if(movement.x != 0)
        {
            transform.localScale = new Vector3(movement.x, 1, 1);
        }
        SwitchAnim();
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void SwitchAnim()
    {
        //magnitude  返回向量的长度(横向和纵向)
        anim.SetFloat("Speed", movement.magnitude);
    }
}
