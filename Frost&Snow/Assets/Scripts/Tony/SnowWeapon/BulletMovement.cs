using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int bulletSpeed;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * bulletSpeed;
        transform.Rotate(0f, 0f, 90f);
        Invoke("DestroyDelay", 5f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DestroyDelay()
    {
        //kill itself after delay
        Destroy(gameObject);
    }
}
