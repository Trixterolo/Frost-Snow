using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCrate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject); 
        }
        //else { return; }
    }
}
