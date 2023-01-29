using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField]
    private float speed = 8f;

    [SerializeField]
    private float jumpingPower = 8f;

    [SerializeField] private Rigidbody2D rb;


    public LayerMask ground;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            float distance = 0.7f;



            Debug.DrawRay(position, direction, Color.green);
            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
            if (hit.collider != null)
            {
                return true;
            }

            return false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}
