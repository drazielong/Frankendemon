using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tutorial by Coding in Flow: https://www.youtube.com/watch?v=Ii-scMenaOQ&list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U
//Edits and tweaks in code by myself - Rosie


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //private makes it so that it cant be affected by other scripts
    private SpriteRenderer sprite;
    private Animator anim; 

    //animation variables
    private float dirX = 0f;
    //adding these serialize field brackets allow us to edit these variables in unity
    //you can also make them public, but that would allow other scripts to fuck w em
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        //affecting components in unity
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); //the raw part instantly drops velocity to 0 
        //if the input is negative or positive, move left or right repsectively
        //By multiplying input by a certain velocity (float number i think) then it will become pos or neg
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y); 

        if (Input.GetButtonDown("Jump")) //get button down isntead of get key down uses unity's input manager system
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //x and y axis parameters
        }

        //if the player is not on the ground disable jumping

        //animation checks
        UpdateAnimation();
    }

    private void UpdateAnimation() 
    {
        //running check
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
        //jumping check

        //if player is in the air, use jumping/freefall sprites
    }
}
