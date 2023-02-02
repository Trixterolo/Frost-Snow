using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAnimationButton : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void OnClick()
    {
        SceneManager.LoadScene("IntroAnimation", LoadSceneMode.Single);
    }
}
