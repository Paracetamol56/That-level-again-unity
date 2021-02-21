using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    Rigidbody2D playerRB;
    SpriteRenderer playerRenderer;
    Animator playerAnim;

    //Valeur de la vitesse max
    public float maxSpeed;
    //Booleen pour connaitre la direction dans laquelle regarde le joueur
    private bool facingRight = true;
    //Valeur de l'intensité des sauts
    public float jumpPower;
    //Tableau de GroundPoints
    public Transform[] GroundPoints;
    public float GroundRadius;
    public LayerMask WhatGround;
    private bool Grounded;
    //Apparence du joueur mort
    public Sprite deadSprite;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {
        Grounded = IsGrounded();
        playerAnim.SetBool("Grounded", Grounded);

        //Saut
        if (Grounded && Input.GetAxis("Jump") > 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
            playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }

        playerAnim.SetFloat("VerticalVelocity", playerRB.velocity.y);

        //Deplacements
        float move = Input.GetAxis("Horizontal");

        //Gestion de la direction
        if (move < 0 && facingRight)
            Flip();
        else if (move > 0 && !facingRight)
            Flip();

        playerRB.velocity = new Vector2(move * maxSpeed, playerRB.velocity.y);
        playerAnim.SetFloat("MoveSpeed", Mathf.Abs(move));
    }

    //Fonction pour changer la direction du regard du joueur
    private void Flip()
    {
        facingRight = !facingRight;
        playerRenderer.flipX = !playerRenderer.flipX;
    }

    //Fonction pour savoir si le personnage touche le sol
    private bool IsGrounded()
    {
        if (playerRB.velocity.y <= 0)
        {
            //Pour chaque points (normaement il y en a 3)
            foreach (Transform point in GroundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, GroundRadius, WhatGround);

                foreach (Collider2D collider in colliders)
                {
                    //Si le collider2D est en collision avec autre chose que le joueur
                    if (collider.gameObject != gameObject)
                    {
                        return true;
                    }
                }

            }
        }
        return false;
    }
    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ouille")
        {
            playerRenderer.sprite = deadSprite;
        }
    }*/
}
