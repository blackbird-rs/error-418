using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    private void Start()
    {
        canvas.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.GetComponent<CanvasGroup>().alpha < 1)
        {
            canvas.GetComponent<CanvasGroup>().alpha += 0.01f;
        }
    }
}
