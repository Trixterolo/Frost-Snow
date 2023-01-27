using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FrostMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    InputAction inputAction;

    [SerializeField] float moveSpeed = 50f;
    [SerializeField] float jumpForce = 50f;
    [SerializeField] private Transform interactor;


    List<Collider2D> switchColliders = new List<Collider2D>();


    private bool isMoving = false;
    private bool isGrounded = true;
    private Vector2 movementInput = Vector2.zero;
    private Vector2 jumpInput;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    switchColliders.ForEach(n => n.SendMessage("Use", SendMessageOptions.DontRequireReceiver));
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoving();
        PlayerJumping();
    }
    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private void OnJump(InputValue jumpValue)
    {
        jumpInput= jumpValue.Get<Vector2>();
    }

    private void PlayerMoving()
    {
        if (movementInput != Vector2.zero)
        {
            rb2d.AddForce(movementInput * moveSpeed * Time.fixedDeltaTime);
            //rb2d.velocity = new Vector2(movementInput.x * moveSpeed * Time.fixedDeltaTime, rb2d.velocity.y);

            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                //gameObject.BroadcastMessage("IsFacingRight", false);
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                //gameObject.BroadcastMessage("IsFacingRight", true);
            }

           // IsMoving = true;
        }
        else
        {
            //rb2d.velocity = Vector2.Lerp(rb2d.velocity, Vector2.zero, idleFriction);
            //IsMoving = false;
        }
    }
    private void PlayerJumping()
    {
        if (!isGrounded && jumpInput != Vector2.zero)
        {
            isGrounded = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
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
