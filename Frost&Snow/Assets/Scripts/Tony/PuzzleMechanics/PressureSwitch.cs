using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : SwitchManager
{

    public int numberColliding = 0;

    private void OnTriggerEnter2D(Collider2D buttons)
    {
        numberColliding++;
        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, 0);
        SwitchOn();
    }

    private void OnTriggerExit2D(Collider2D buttons)
    {
        numberColliding--;
        if (numberColliding == 0)
        {
           // gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, 0);
            
            SwitchOff();
        }
    }
}