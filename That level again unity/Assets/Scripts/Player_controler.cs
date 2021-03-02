using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //Game object de la porte
    public Door_script Door;
    //Apparence du joueur mort
    public Transform DeadBody;
    //Point de respawn
    public Transform SpawnPoint;
    int deathTriggerCount = 1;

    //Variable de Gameplay
    int pressCount = 0;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

        Physics2D.IgnoreCollision(DeadBody.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    void FixedUpdate()
    {
        deathTriggerCount = 1;
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

    public void killMe()
    {
        transform.position = SpawnPoint.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ouille")
        {
            -- deathTriggerCount; //Cette variable sert a ne pas respawn plusieur fois au cas ou le joueur touche differnets "ouille" à la meme frame
            if (deathTriggerCount == 0)
            {
                DeadBody.position = transform.position;
                DeadBody.GetComponent<Rigidbody2D>().velocity = playerRB.velocity;

                transform.position = SpawnPoint.position;
                playerRB.velocity = Vector3.zero;
                if (!facingRight)
                    Flip();
            }
        }

        else if (col.name == "TriggerSuccess")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }

        else if (col.name == "Button")
        {
            switch (SceneManager.GetActiveScene().buildIndex - 1)
            {
                case 1:
                    // 1. Plain and simple
                    Door.OpenDoor();
                    break;
                case 2:
                    // 2. Try more
                    ++pressCount;
                    if (pressCount > 5)
                    {
                        Door.OpenDoor();
                    }
                    break;
                case 6:
                    // 6. Press harder
                    if (playerRB.velocity.y <= -10)
                    {
                        Door.OpenDoor();
                    }
                    break;
            }
        }

        else if (col.name == "PauseButton")
        {
            if (SceneManager.GetActiveScene().buildIndex - 1 == 7)
                Door.OpenDoor();
        }


    }
}