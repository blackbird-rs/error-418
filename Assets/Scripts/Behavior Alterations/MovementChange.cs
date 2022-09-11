using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChange : MonoBehaviour
{
    public bool triggerDetector = false;

    private void OnTriggerEnter2D(Collider2D collision){
        triggerDetector = true;
    }
}
