using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBite : MonoBehaviour
{
    private GameObject currentObject; //current -> hitObject
    //[SerializeField] private GameObject originalObject;
    [SerializeField] private Transform grabPoint;
    [SerializeField] private LayerMask grabLayer;
    private float maxDistance = 1.5f;
    private int grabState;

    [SerializeField] WolfMovement wolfMovement;
    //[SerializeField] OpenGate openGate;
    [SerializeField] BoxCollider2D colliderChainHead;
    [SerializeField] GameObject spikeGate;
    [SerializeField] OpenGate openGate;

 

    private void Awake()
    {
        wolfMovement = GetComponent<WolfMovement>();
    }

    private void Update()
    {
        GrabStates();

    }



    private void GrabStates()
    {
        switch (grabState)
        {
            //standard
            case 0:
                GrabChain();
                if (currentObject)
                {
                    grabState = 1;
                }
                wolfMovement.moveState = 0;
                break;
            //holder
            case 1:
                currentObject.transform.position = new Vector2(grabPoint.position.x, currentObject.transform.position.y);
                ReleaseChain();
                if (!currentObject)
                {
                    grabState = 0;
                }
                wolfMovement.moveState = 1;

                break;

        }
    }

    private void GrabChain()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            RaycastHit2D hitObject = Physics2D.Raycast(transform.position, Vector2.right, maxDistance, grabLayer);
            if (hitObject)
            {
       
                currentObject = hitObject.transform.gameObject;

                

            }
        }
    }

    private void ReleaseChain()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            currentObject = null;
            openGate.KeyPickedUp();
            colliderChainHead.enabled = false;
            spikeGate.SetActive(false);
        }

    }



}
