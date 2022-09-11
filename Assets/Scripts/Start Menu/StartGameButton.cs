using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    Color textColor;
    // Start is called before the first frame update
    void Start()
    {
        textColor = text.color;
        textColor.a = 0.0f;
        text.color = textColor;
    }

    // Update is called once per frame
    void Update()
    {
        textColor = text.color;
        textColor.a += 0.005f;
        text.color = textColor;
    }
}
