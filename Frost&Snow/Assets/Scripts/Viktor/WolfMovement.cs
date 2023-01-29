using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
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
        horizontal = Input.GetAxisRaw("HorizontalWolf");

        //Jump
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //Raycast grounded check
        bool IsGrounded()
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

        if (Input.GetKeyDown(KeyCode.T))
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

    private void OnTriggerEnter2D(Collider2D switches)
    {
        switchColliders.Add(switches);
    }
    private void OnTriggerExit2D(Collider2D switches)
    {
        switchColliders.Remove(switches);
    }
}
