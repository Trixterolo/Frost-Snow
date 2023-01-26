using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReached : MonoBehaviour
{
    [SerializeField] int playerRequirement;
    public int playerReached;
   // public bool goalOpen = false;

    private void OnTriggerEnter2D(Collider2D player)
    {
        playerReached++;
        if(player.CompareTag("Player") && playerReached >= playerRequirement)
        {
            //Next stage
          //  goalOpen= true;
            Debug.Log("Next level!");
        }
       // goalOpen = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerReached--;
    }

}
