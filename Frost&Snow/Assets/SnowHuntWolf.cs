using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowHuntWolf : MonoBehaviour
{
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Frost") || collision.CompareTag("Snow"))
            {
                Debug.Log(collision.gameObject.name + " died");
                Destroy(collision.gameObject);
            }
        }
}

