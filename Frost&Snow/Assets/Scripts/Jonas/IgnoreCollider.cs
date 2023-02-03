using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollider : MonoBehaviour
{
    public Collider2D playerCollider;
    public Collider2D obstacleCollider;

    void Start()
    {
        Physics2D.IgnoreCollision(playerCollider, obstacleCollider);
    }

}
