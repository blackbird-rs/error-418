using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Image blackScreen;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => blackScreen.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
