using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReached : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoader;
    [SerializeField] int playerRequirement;
    public int playerReached;
   // public bool goalOpen = false;

    private void OnTriggerEnter2D(Collider2D player)
    {
        playerReached++;
        if((player.CompareTag("Frost") || player.CompareTag("Snow")) && playerReached >= playerRequirement)
        {
            Debug.Log("Next level!");
            levelLoader.LoadNextLevel();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerReached--;
    }

}
