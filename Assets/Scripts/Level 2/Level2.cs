using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;

    [SerializeField] Player player;
    [SerializeField] Collider2D portCollider;
    [SerializeField] TextMeshProUGUI interactText;

    [SerializeField] float waitBetweenChars;
    [SerializeField] float waitBetweenLines;

    State state;

    void Start()
    {
        state = startingState;
        StartCoroutine(ShowText(state));
    }

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
        portCollider.isTrigger = true;
        interactText.enabled = true; 
    }
}
