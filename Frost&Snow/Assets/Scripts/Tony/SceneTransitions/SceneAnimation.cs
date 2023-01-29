using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneAnimation : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform rectTransform;
    private Tween fadeTween;


    //public Animator transition;
    public string sceneName;
    public float transitionTime = 1f;



    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            SceneManager.LoadScene("CampScene1");

        });
    }
    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if(fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
     

        fadeTween.onComplete += onEnd;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    private IEnumerator LoadLevel(string sceneIndex)
    {
        //Play animation
        FadeOut(1f);
        //Wait for animation stop playing
        yield return new WaitForSeconds(transitionTime);
        fadeTween.Kill();
        //Load Scene
        SceneManager.LoadScene(sceneIndex);
    }


    //test
    private IEnumerator TestFade()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("FadingIn!");
        FadeIn(3f);
        yield return new WaitForSeconds(3f);
        Debug.Log("FadingOut!");
        FadeOut(3f);
    }
}
