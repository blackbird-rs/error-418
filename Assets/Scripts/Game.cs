using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;

    [SerializeField] GameObject redPill;
    [SerializeField] GameObject bluePill;

    State state;
    float timer = 0;

    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateText();
    }

    void Update()
    {
        timer += Time.deltaTime;
        PickAPill();        
    }

    private void PickAPill()
    {
        var nextStates = state.GetNextStates();
        if (Input.GetKeyDown(KeyCode.B))
        {
            state = nextStates[0];
            textComponent.text = state.GetStateText();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            state = nextStates[1];
            textComponent.text = state.GetStateText();
        }
    }
}
