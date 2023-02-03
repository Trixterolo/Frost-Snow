using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb2d;
    private float width;

    [SerializeField] private float scrollSpeed = -2f;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        width = collider.size.x;
        collider.enabled = false;

        rb2d.velocity = new Vector2(scrollSpeed, 0);

       // ResetObstacle();
    }

    private void Update()
    {
        if(transform.position.x < -width)
        {
            Vector2 resetPostion = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPostion;
            //ResetObstacle(); 
        }
    }

    //void ResetObstacle() //infinite spawn within the stage.
    //{
    //    transform.GetChild(0).localPosition = new Vector3(0, Random.Range(-1, 3), 0);
    //}

}
