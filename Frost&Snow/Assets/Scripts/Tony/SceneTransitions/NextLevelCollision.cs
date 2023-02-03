using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelCollision : MonoBehaviour
{

    [SerializeField] LevelLoader levelLoader;

    private void OnTriggerEnter2D(Collider2D player)
    {
        levelLoader.LoadNextLevel();
    }

}
