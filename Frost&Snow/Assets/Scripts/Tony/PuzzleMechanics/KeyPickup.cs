using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] BoxCollider2D normalBoxCollider2D;
    [SerializeField] OpenGate openGate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frost") || collision.CompareTag("Snow"))
        {
            //unlock goal gate

            //This adds up to 3 switches due to 3 colliders.
            Debug.Log("Key picked up");
            openGate.KeyPickedUp();

            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        rb2d.gravityScale = 0f;

        normalBoxCollider2D.enabled = false;
    }

    public void EnableGravityRb2D()
    {
        rb2d.gravityScale = 1f;
        normalBoxCollider2D.enabled = true;

    }
}
