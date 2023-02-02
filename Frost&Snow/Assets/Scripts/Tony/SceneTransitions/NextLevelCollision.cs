using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        Invoke("NextLevel", 0.5f);
    }


    private void NextLevel()
    {
        SceneManager.LoadScene("Level4", LoadSceneMode.Single);
    }
}
