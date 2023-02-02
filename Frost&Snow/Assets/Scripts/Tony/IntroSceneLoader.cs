using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLoader : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("IntroScene", LoadSceneMode.Single);
    }
}
