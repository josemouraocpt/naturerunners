using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    private Rigidbody2D rig;
    public bool isJumping;
    private Animator anim;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);//Velocidade de movimentação.
        transform.position += movement * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f)//Caso esteja andando pode continuar.
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        if(Input.GetAxis("Horizontal") < 0f)//Caso parado pode mudar a direção do personagem.
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)//Caso não detectada movimentação o personagem fica parado no lugar.
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 6)//Caso ja esteja no ar o personagem não consegue pular novamente.
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if(col.gameObject.tag == "Armadilha")//Ao tocar um objeto "Armadilha" o jogar morre.
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }
}
