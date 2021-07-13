using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer SpriteRenderer;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }


    void Update()
    {

        //jump
        if(Input.GetButtonDown("Jump"))
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        //Stop Speed
        if(Input.GetButtonUp("Horizontal")){
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //Direction Sprite
        if(Input.GetButton("Horizontal"))
        SpriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Animator
        if(rigid.velocity.normalized.x == 0)
            anim.SetBool("isWalk", false);
        else
            anim.SetBool("isWalk", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move By Key Control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed) // Right Max Speed
             rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1)) // Left Max Speed
             rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
    }
}
