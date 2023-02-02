using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    Transform player;
   
    
    void Update()
    {
        Vector3 cameraPosition = transform.position;
        if (player.transform.position.x > -5)
            cameraPosition.x = player.position.x;
        if (player.transform.position.y < -5)
            cameraPosition.y = player.position.y;

        cameraPosition.z = -11;

        transform.position = cameraPosition;
    }
}
