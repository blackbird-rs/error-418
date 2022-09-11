using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] State state;
    [SerializeField] float waitBetweenChars;
    [SerializeField] float waitBetweenLines;

    private string currentText = "";
    private string fullText = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator ShowText()
    {
        fullText = state.GetStateText();
        for (int i = 0; i<fullText.Length; i++)
        {
            currentText += fullText.Substring(i, 1);
            yield return new WaitForSeconds(waitBetweenChars);
        }
    }
}
