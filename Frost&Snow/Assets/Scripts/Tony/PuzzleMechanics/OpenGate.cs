using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    Collider2D playerCollider;
   // Animator gateAnimator;

    [SerializeField] private bool isGateOpen;

    [SerializeField] private int switchesToOpen;
    private int switches;
    // Start is called before the first frame update
    void Start()
    {
        //gateAnimator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GateOpen()
    {
        switches++;
        if (!isGateOpen && switches >= switchesToOpen)
        {
            SetState(true);
            Debug.Log("Door Open!");

        }
    }

    public void GateClose()
    {
        switches--;
        if (isGateOpen && switches < switchesToOpen)
        {
            SetState(false);
            Debug.Log("Door Closed!");


        }
    }


    public void ToggleDoor()
    {
        if (isGateOpen)
        {
            GateClose();

        }
        else
        {
            GateOpen();

        }

    }
    private void SetState(bool open)
    {
        isGateOpen = open; //Så vi starter med at døra er Closed. Dermed er SetState = true.
        //gateAnimator.SetBool("Open", open);

        playerCollider.isTrigger = open;
    }
}

