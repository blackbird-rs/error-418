using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    public Image blackScreen;
    public Animator animator;
    [SerializeField] Object nextScene;
    
    public void LoadNextScene()
    {
        /*StartCoroutine(Fading());*/

        SceneManager.LoadScene(1);
    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => blackScreen.color.a == 1);
        SceneManager.LoadScene(nextScene.name);
    }
}
