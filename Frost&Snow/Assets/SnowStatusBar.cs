using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SnowStatusBar : MonoBehaviour
{
    [SerializeField] HareMovement hareMovement;
    public float minimum;

    //public float maximum;
    //public float current;
    public Image mask;
    public Image fill;
    public Color color;

    public float maximumHealth = 100f;
    public float currentHealth;
    public float moveDamage = 0.05f;
    // Start is called before the first frame update


    void Start()
    {
       // currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maximumHealth) currentHealth = maximumHealth;
        GetCurrentFill();
    }

    public void GetCurrentFill()
    {
        float currentOffset = currentHealth - minimum;
        float maximumOffset = maximumHealth - minimum;

        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;


        fill.color = color;

    }

    public void Damage()
    {
        if (currentHealth > 0)
        {
            currentHealth -= moveDamage;
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Player died to Exhaustion");
            hareMovement.DeathState();
            Invoke("RestartLevel", 1f);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
