using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableChain : MonoBehaviour
{
    [SerializeField] KeyPickup keyPickup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            keyPickup.EnableGravityRb2D();
            gameObject.SetActive(false);
            Destroy(gameObject); 
        }
        //else { return; }
    }



    private void DestroyYourself()
    {
        print("Rock Gate destroyed");
        Destroy(gameObject);
    }
}
