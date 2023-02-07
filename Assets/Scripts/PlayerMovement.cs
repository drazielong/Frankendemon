//Tutorial by Coding in Flow: https://www.youtube.com/watch?v=Ii-scMenaOQ&list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U
//Edits and tweaks in code by myself

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb; //private makes it so that it cant be affected by other scripts
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Animator anim; 

    [SerializeField] private LayerMask jumpableGround;

    //animation variables
    private float dirX = 0f;
    //adding these serialize field brackets allow us to edit these variables in unity
    //you can also make them public, but that would allow other scripts to fuck w em
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 12f;

    //enum is making our own data type that holds whatever is in the curly braces
    private enum MovementState { idle, run, jump, fall }

    // Start is called before the first frame update
    private void Start()
    {
        //affecting components in unity
        rb = GetComponent<Rigidbody2D>(); 
        collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        //stop movement if ur in dialogue... problem is u keep sliding for a bit if u activate while running
        //its not too bad besides that but i would like to just stop dead in your tracks
        //also you are stuck in ur last animation, i want it to default to idle
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            
            return;
        }
        
        dirX = Input.GetAxisRaw("Horizontal"); //the raw part instantly drops velocity to 0 
        //if the input is negative or positive, move left or right repsectively
        //By multiplying input by a certain velocity (float number i think) then it will become pos or neg
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y); 
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) //get button down isntead of get key down uses unity's input manager system
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //x and y axis parameters
        }

        //animation checks
        UpdateAnimation();
    }

    private void UpdateAnimation() 
    {

        MovementState state;

        //running check
        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //airborne check
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        //I really need to get the unity extension so i can see the parameters for unity shit
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
    }
}
