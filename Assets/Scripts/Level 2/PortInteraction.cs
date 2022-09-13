using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortInteraction : MonoBehaviour
{
    public Collider2D portCollider;
    public Collider2D playerCollider;

    public Image terminalBackground;
    public TextMeshProUGUI terminalText;
    public TMP_InputField terminalInput;
    public TextMeshProUGUI textComponent;
    public Player player;
    public GameObject exit;

    [SerializeField] State startingState;
    [SerializeField] float waitBetweenChars;
    [SerializeField] float waitBetweenLines;

    State state;
    State[] states;

    private bool correctCommand = false;
    private bool exitEnabled = false;

    private void Start()
    {
        state = startingState;
        states = startingState.GetNextStates();
    }

    private void Update()
    {
        if (portCollider.IsTouching(playerCollider)){
            if (Input.GetKeyDown(KeyCode.E))
            {
                terminalBackground.enabled = true;
                terminalText.enabled = true;
                terminalInput.enabled = true;
                terminalInput.Select();
                terminalInput.ActivateInputField();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && correctCommand == false)
        {
            if(terminalInput.text == "Debug.Log")
            {
                terminalText.text = states[0].GetStateText();
                terminalInput.enabled = false;
                terminalInput.textComponent.enabled = false;
                correctCommand = true;
            }
            else
            {
                terminalText.text = states[1].GetStateText();
                terminalInput.Select();
                terminalInput.ActivateInputField();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Q) && correctCommand == true)
        {
            terminalBackground.enabled = false;
            terminalText.enabled = false;
            terminalInput.enabled = false;
            state = states[0].GetNextStates()[0];
            StartCoroutine(ShowText(state));
        }
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
        if(correctCommand == true)
        {
            player.FixMovement();
            StartCoroutine(ShowText(state.GetNextStates()[0]));
            exitEnabled = true;
        }
        if(exitEnabled == true)
        {
            yield return new WaitForSeconds(10f);
            exit.SetActive(true);
        }
    }
}
