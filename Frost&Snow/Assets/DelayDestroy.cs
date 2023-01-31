using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayDestroyText", 15f); 
    }



    void DelayDestroyText()
    {
        Destroy(gameObject);
    }
}
