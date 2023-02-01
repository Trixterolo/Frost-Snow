using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPickUp : MonoBehaviour
{
    [SerializeField] SnowStatusBar snowBar;
    [SerializeField] FrostStatusBar frostBar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snow"))
        {
            snowBar.Heal();
            print("Snow food picked up!");
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Frost"))
        {
            frostBar.Heal();
            print("Frost food picked up!");
            Destroy(gameObject);
        }
    }
}
