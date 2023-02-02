using System.Collections.Generic;
using UnityEngine;

public class HareMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float jumpingPower = 8f;

    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public List<Collider2D> switchColliders = new List<Collider2D>();

    public LayerMask ground;

    private bool isFacingRight = true;

    Animator animator;
    private string currentState;

    //Animation States, can also be done witn Enum
    const string SNOW_IDLE = "Snow_Idle";
    const string SNOW_RUN = "Snow_Run";
    const string SNOW_JUMP = "Snow_Jump";
    // const string SNOW_SHOOT = "Snow_Shoot";

    //StatusBar
    [SerializeField] SnowStatusBar statusBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("HorizontalHare");

        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            ChangeAnimationState(SNOW_JUMP);

        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            ChangeAnimationState(SNOW_JUMP);
        }



        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            switchColliders.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
        }

        
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

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

            if(horizontal != 0)
            {
                ChangeAnimationState(SNOW_RUN);
            }
            else
            {
                ChangeAnimationState(SNOW_IDLE);
            }
        }

        if(horizontal > 0f || horizontal <0f || rb.velocity.y > 0f)
        {
            statusBar.Damage();
        }
    }
    //Raycast grounded check
    public bool IsGrounded()
    {


        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;



        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
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

    private void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void DeathState()
    {
        animator.enabled = false;
        speed = 0;
        rb.velocity = Vector2.zero;

    }
}
