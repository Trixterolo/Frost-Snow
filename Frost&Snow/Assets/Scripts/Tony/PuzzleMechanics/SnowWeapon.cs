using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowWeapon : MonoBehaviour
{
    [SerializeField] InstantiateBullet bulletAmmo;
    [SerializeField] SpriteRenderer arrowAimRenderer;
    [SerializeField] GameObject ammoText;

    private void Awake()
    {
        arrowAimRenderer.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Snow"))
        {
            if(bulletAmmo) 
            {
                if(!arrowAimRenderer.enabled)
                {
                    arrowAimRenderer.enabled = true;
                }
                if (!ammoText.active)
                {
                    ammoText.active = true;
                }
                bulletAmmo.AddAmmo(bulletAmmo.maxAmmosize);
                Debug.Log("Carrot Picked Up!");
                Destroy(gameObject);
            }
        }  
    }
}
