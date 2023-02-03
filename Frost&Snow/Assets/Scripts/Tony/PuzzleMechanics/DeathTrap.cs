using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frost") || collision.CompareTag("Snow"))
        {
            Debug.Log(collision.gameObject.name + " died");
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            Invoke("RestartLevel",1f);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
