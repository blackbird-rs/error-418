using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour
{
    public State startingState;
    public Image blackScreen;
    public Animator animator;

    [SerializeField] float waitBetweenLines;
    [SerializeField] float waitBetweenChars;
    [SerializeField] TextMeshProUGUI textComponent;

    State state;
    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        StartCoroutine(ShowText(state));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowText(State state)
    {
        string currentText = "";
        string fullText = state.GetStateText();
        for (int i = 0; i < fullText.Length; i++)
        {
            if (fullText.Substring(i, 1) == "\n" && fullText.Substring(i + 1, 1) == "\n")
            {
                yield return new WaitForSeconds(waitBetweenLines);
                currentText = "";
                i++;
            }
            currentText += fullText.Substring(i, 1);
            textComponent.text = currentText;
            yield return new WaitForSeconds(waitBetweenChars);
        }
        yield return new WaitForSeconds(3f);
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => blackScreen.color.a == 1);
        SceneManager.LoadScene(0);
    }
}
