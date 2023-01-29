using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startingSceneTransition;
    [SerializeField] private GameObject endingSceneTransition;

    // Start is called before the first frame update
    void Start()
    {
        startingSceneTransition.SetActive(true);
        StartCoroutine(DisableStartingSceneTransition());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            endingSceneTransition.SetActive(true);
            StartCoroutine(EnableStartingSceneTransition());
            SceneManager.LoadScene("CampScene2");
        }
    }

    private IEnumerator DisableStartingSceneTransition()
    {

        yield return new WaitForSeconds(5f);
        startingSceneTransition.SetActive(false);
    }

    private IEnumerator EnableStartingSceneTransition()
    {

        yield return new WaitForSeconds(1.5f);
        startingSceneTransition.SetActive(true);
    }
}
