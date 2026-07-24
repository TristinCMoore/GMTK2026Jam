using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject levelSelectScreen;

    public void StartGame()
    {
        titleScreen.SetActive(false);
        levelSelectScreen.SetActive(true);
    }
    public void LoadScene(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        return;
        fadeAnimator.Play("FadeToBlack");
        StartCoroutine(DelayFade(sceneName));
    }

    IEnumerator DelayFade(string sceneName)
    {
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(sceneName);
    }
}
