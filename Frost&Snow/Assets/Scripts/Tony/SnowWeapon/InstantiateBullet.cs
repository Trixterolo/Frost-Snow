using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour
{
    public GameObject myInstantiateBullet = null;


    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.P))
        {
            OnFire();
        }
    }
    public void OnFire()
    {
        GameObject bullet = Instantiate(myInstantiateBullet, transform.position, transform.rotation);
    }


}
