using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomTimeGenerator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] int frameSkips;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {
            var hour = Random.Range(0, 23).ToString("D2");
            var minute = Random.Range(0, 59).ToString("D2");

            time.text = hour + ":" + minute;
        }
        i++;
        if(i == frameSkips)
        {
            i = 0;
        }

    }
}
