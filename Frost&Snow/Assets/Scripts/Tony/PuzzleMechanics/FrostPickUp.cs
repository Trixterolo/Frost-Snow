using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frost"))
        {
            print("Frost food picked up!");
            Destroy(gameObject);
        }
    }
}
