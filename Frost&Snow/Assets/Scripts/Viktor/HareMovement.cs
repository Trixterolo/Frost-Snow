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
    List<Collider2D> switchColliders = new List<Collider2D>();


    public LayerMask ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("HorizontalHare");

        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
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
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
            //gameObject.BroadcastMessage("IsFacingRight", false);
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
            //gameObject.BroadcastMessage("IsFacingRight", true);
        }
    }
    //Raycast grounded check
    private bool IsGrounded()
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
    }

}
