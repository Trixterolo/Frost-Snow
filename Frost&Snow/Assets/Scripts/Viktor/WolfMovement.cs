using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    private float horizontal;

    [SerializeField]
    private float jumpingPower = 8f;

    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    List<Collider2D> switchColliders = new List<Collider2D>();
    public LayerMask ground;

    [SerializeField] WolfBite wolfBite;
    [HideInInspector] public int moveState;
    [SerializeField] private float defaultSpeed = 8f;
    private float currentSpeed;
    private float grabSpeed = 0f;

    bool isFacingRight = true;

    Animator animator;
    private string currentState;

    //Animation States, can also be done witn Enum
    const string FROST_IDLE = "Frost_Idle";
    const string FROST_RUN = "Frost_Run";
    const string FROST_JUMP = "Frost_Jump";
    // const string SNOW_SHOOT = "Snow_Shoot";

    //Damage
    [SerializeField] FrostStatusBar statusBar;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        wolfBite = GetComponent<WolfBite>();

        animator = GetComponent<Animator>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("HorizontalWolf");

        MoveState();

        if (Input.GetKeyDown(KeyCode.T))
        {
            switchColliders.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * currentSpeed, rb.velocity.y);

        //flip based on direction
        if (rb.velocity.x < 0 && isFacingRight)
        {
            Flip();

                //gameObject.BroadcastMessage("IsFacingRight", false);
        }
        else if (rb.velocity.x > 0 && !isFacingRight)
        {
            Flip();

                //gameObject.BroadcastMessage("IsFacingRight", true);
        }



        //Animations
        if (IsGrounded() && rb.velocity.y <= Mathf.Epsilon)
        {

            if (horizontal != 0)
            {
                ChangeAnimationState(FROST_RUN);
            }
            else
            {
                ChangeAnimationState(FROST_IDLE);
            }
        }

        //toggle grab
        if (moveState == 0)
        {
            currentSpeed = defaultSpeed;
        }
        else
        {
            currentSpeed = grabSpeed;
        }


        //Damaged when move
        if (horizontal > 0f || horizontal < 0f || rb.velocity.y > 0f)
        {
            statusBar.Damage();
        }
    }


    private void OnTriggerEnter2D(Collider2D switches)
    {
        switchColliders.Add(switches);
    }
    private void OnTriggerExit2D(Collider2D switches)
    {
        switchColliders.Remove(switches);
        switchColliders.Clear();
    }

    private void MoveState()
    {
        switch (moveState)
        {
            case 0:
                Jumping();
                break;

            case 1:
                break;


        }
    }

    private void Jumping()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            ChangeAnimationState(FROST_JUMP);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            ChangeAnimationState(FROST_JUMP);
        }

        //bool IsGrounded()
        //{
        //    Vector2 position = transform.position;
        //    Vector2 direction = Vector2.down;
        //    float distance = 1.2f;



        //    Debug.DrawRay(position, direction, Color.green);
        //    RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
        //    if (hit.collider != null)
        //    {
        //        return true;
        //    }

        //    return false;

        //}
    }

    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.2f;



        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
        if (hit.collider != null)
        {
            return true;
        }

        return false;

    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }

    public void DeathState()
    {
        defaultSpeed = 0;
        rb.velocity = Vector2.zero;
        
    }
}
