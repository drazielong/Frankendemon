//Tutorial by Coding in Flow: https://www.youtube.com/watch?v=Ii-scMenaOQ&list=PLrnPJCHvNZuCVTz6lvhR81nnaf1a-b67U

using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;
    private Animator anim; 

    [SerializeField] private LayerMask jumpableGround;

    //animation variables
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 12f;

    //enum is making our own data type that holds whatever is in the curly braces
    private enum MovementState { idle, run, jump, fall }

    public static bool isPaused;
    public GameObject pauseMenu;
    public GameObject pauseResolution;

    // Start is called before the first frame update
    private void Start()
    {
        //affecting components in unity
        rb = GetComponent<Rigidbody2D>(); 
        collider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //testing buttons
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (Input.GetButtonDown("Quit"))
        {
            Application.Quit();
        }

        //stop movement if ur in dialogue OR paused OR cutscene is playing
        if (DialogueManager.GetInstance().dialogueIsPlaying || isPaused || CutsceneController.cutsceneIsPlaying == true)
        {
            rb.velocity = new Vector2 (0 * moveSpeed, rb.velocity.y);
            anim.SetInteger("state", (int)MovementState.idle);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !DialogueManager.GetInstance().dialogueIsPlaying)
        { 
            PauseGame();
        }

        dirX = Input.GetAxisRaw("Horizontal"); //the raw part instantly drops velocity to 0 
        //if the input is negative or positive, move left or right repsectively
        //By multiplying input by a certain velocity (float number i think) then it will become pos or neg
        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y); 

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //x and y axis parameters
        }

        //animation checks
        if (!isPaused)
        {
            UpdateAnimation();
        }
    }

    private void UpdateAnimation() 
    {

        MovementState state;

        //running check - switch?
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
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
    }

    public void TeleportPlayer(float x, float y, float z)
    {
        //pause player movement? 
        this.transform.position = new Vector3(x, y, z);
    }

    public void PauseGame()
    {
        //select "resolution" obj from the pause menu as "first selected" in event sys
        EventSystem.current.SetSelectedGameObject(pauseResolution);
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);   
    }

    //moved to menus
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
