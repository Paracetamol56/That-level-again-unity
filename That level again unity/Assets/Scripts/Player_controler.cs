using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controler : MonoBehaviour
{
    Rigidbody2D playerRB; // Propriété qui tiendra en réféence le rigid body de notre player
    SpriteRenderer playerRenderer; // Propriété qui tiendra la réféence du sprite rendered de notre player
    public float maxSpeed; // Vitesse maximale que notre player peut atteindre en se délaçant
    bool facingRight = true; // Par défaut, notre player regarde à droite
    public float jumpPower;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); // On utilise GetComponent car notre Rb se situe au sein du même objet
        playerRenderer = GetComponent<SpriteRenderer>(); //Même chose pour le composant SpriteRender
    }

    
    void Update()
    {
        if (Input.GetAxis("Jump") > 0)
        { // On verifie si l'utilisateur est au sol, et si l'input jump est en appui
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f); // On defini la velocite y a 0 pour etre sur d'avoir la mêe hauteur quelque soit le contexte
            playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // On ajoute de la force sur notre rigidbody afin de le faire s'envoler, on precise bien un forcement a impulse pour avoir toute la force d'un seul coup
        }

        float move = Input.GetAxis("Horizontal");

        if (move < 0 && facingRight)
            Flip();
        else if (move > 0 && !facingRight)
            Flip();

        playerRB.velocity = new Vector2(move * maxSpeed, playerRB.velocity.y); // On utilise vector 2 car nous sommes dans un contexte 2D
    }

    void Flip()
    {
        facingRight = !facingRight; // On change la valeur du boolen facing right par son contraire, représentant la direction du personnage
        playerRenderer.flipX = !playerRenderer.flipX; // Même chose ici pour que notre flipx et  facingRight soient en phase
    }
}
