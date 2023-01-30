using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBullet : MonoBehaviour
{
    public GameObject myInstantiateBullet = null;

    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnFire();
        }
    }
    void OnFire()
    {
        GameObject bullet = Instantiate(myInstantiateBullet, transform.position, transform.rotation);

    }
}
