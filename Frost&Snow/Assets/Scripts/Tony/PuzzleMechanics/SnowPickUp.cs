using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snow") || collision.CompareTag("Frost"))
        {
            print("Snow food picked up!");
            Destroy(gameObject);
        }
    }
}
