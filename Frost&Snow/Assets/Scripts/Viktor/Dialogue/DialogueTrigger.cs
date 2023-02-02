using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [SerializeField] private GameObject pressButton;

    private bool playerInRange;

    private bool canStart;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        canStart = true;
        
    }

    

    private void Update()
    {
        //This is if you want to trigger by interacting inside a collider

        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (canStart)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON); //nice way to get info from other scripts?
                canStart = false;
            }
        } else
        {
            visualCue.SetActive(false);
            pressButton.SetActive(false);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
            
    }
}
