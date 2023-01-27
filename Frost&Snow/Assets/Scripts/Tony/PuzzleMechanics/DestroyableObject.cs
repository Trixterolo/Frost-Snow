using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable") || collision.CompareTag("Projectile"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject); 
        }
    }

    private void DestroyYourself()
    {
        print("Rock Gate destroyed");
        Destroy(gameObject);
    }
}
