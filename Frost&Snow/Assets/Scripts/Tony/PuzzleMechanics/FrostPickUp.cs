using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostPickUp : MonoBehaviour
{
    [SerializeField] FrostStatusBar frostBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frost"))
        {
            frostBar.Heal();
            print("Frost food picked up!");
            Destroy(gameObject);
        }
    }
}
