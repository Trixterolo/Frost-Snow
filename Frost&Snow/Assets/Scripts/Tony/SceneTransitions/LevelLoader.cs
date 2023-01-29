using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public string sceneName;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    LoadNextLevel();
        //}
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    public IEnumerator LoadLevel(string sceneIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait for animation stop playing
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        SceneManager.LoadScene(sceneIndex);
    }
}
