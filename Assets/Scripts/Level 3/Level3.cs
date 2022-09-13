using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level3 : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject floor;
    [SerializeField] State startingState;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] Collider2D portCollider;

    [SerializeField] float waitBetweenLines;
    [SerializeField] float waitBetweenChars;

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
        portCollider.isTrigger = true;
    }
}
