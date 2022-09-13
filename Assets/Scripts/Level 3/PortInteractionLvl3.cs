using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortInteractionLvl3 : MonoBehaviour
{
    public Collider2D portCollider;
    public Collider2D playerCollider;

    public Image labyrinthBackground;
    public GameObject labyrinthWalls;
    public GameObject labyrinthPlayer;
    public TextMeshProUGUI textComponent;
    public Player player;
    public GameObject exit;
    public GameObject apple;

    State state;
    State[] states;

    private void Start()
    {

    }

    [System.Obsolete]
    private void Update()
    {
        if (portCollider.IsTouching(playerCollider))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                labyrinthBackground.enabled = true;
                labyrinthWalls.active = true;
                labyrinthPlayer.active = true;
                apple.active = true;
                player.enabled = false;
                player.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
