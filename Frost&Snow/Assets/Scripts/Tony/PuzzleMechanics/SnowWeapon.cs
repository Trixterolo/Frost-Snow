using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowWeapon : MonoBehaviour
{
    [SerializeField] int pineconeAmmo = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pineconeAmmo++;
            Debug.Log("Pinecone Picked Up!");
            Destroy(gameObject);
        }  
    }
}
