using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Snow")
        {

            collision.gameObject.transform.SetParent(transform);
            //collision.gameObject.GetComponent<Animator>().enabled = false;

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Snow")
        {

            collision.gameObject.transform.SetParent(null);
            //collision.gameObject.GetComponent<Animator>().enabled = true;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    private void OnCollisionExit(Collision collision)
    {


    }
}
