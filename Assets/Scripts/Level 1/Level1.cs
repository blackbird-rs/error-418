using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;

    [SerializeField] GameObject redPill;
    [SerializeField] GameObject bluePill;
    [SerializeField] Player player;
    [SerializeField] GameObject exitButton;

    [SerializeField] float waitBetweenChars;
    [SerializeField] float waitBetweenLines;

    State state;
    bool finishedTalking = false;
    bool greenPillPicked = false;

    void Start()
    {
        state = startingState;
        StartCoroutine(ShowText(state));
    }

    void Update()
    {
        PickAPill();
    }

    private void PickAPill()
    {
        var nextStates = state.GetNextStates();
        if(finishedTalking == true)
        {
            if (Input.GetKeyDown(KeyCode.G) && greenPillPicked == false)
            {
                state = nextStates[0];
                StartCoroutine(ShowText(state));
                greenPillPicked = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && greenPillPicked == false)
            {
                state = nextStates[1];
                StartCoroutine(ShowText(state));
                player.EnableMovement();
            }
            else if (Input.GetKeyDown(KeyCode.Y) && greenPillPicked == true)
            {
                state = nextStates[0];
                StartCoroutine(ShowText(state));
                StartCoroutine(ShowExitButton());
            }
            else if (Input.GetKeyDown(KeyCode.N) && greenPillPicked == true)
            {
                state = nextStates[1];
                StartCoroutine(ShowText(state));
                player.EnableMovement();
            }
        }
    }

    IEnumerator ShowText(State state)
    {
        string currentText = "";
        string fullText = state.GetStateText();
        for (int i = 0; i < fullText.Length; i++)
        {
            if(fullText.Substring(i, 1) == "\n" && fullText.Substring(i+1, 1) == "\n")
            {
                yield return new WaitForSeconds(waitBetweenLines);
                currentText = "";
                i++;
            }
            currentText += fullText.Substring(i, 1);
            textComponent.text = currentText;
            yield return new WaitForSeconds(waitBetweenChars);
        }
        if(finishedTalking == false)
        {
            finishedTalking = true;
        }
    }

    IEnumerator ShowExitButton()
    {
        yield return new WaitForSeconds(10f);
        exitButton.SetActive(true);
    }
}
