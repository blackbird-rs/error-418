using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LabyrinthPlayer : MonoBehaviour
{
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float padding = 0.10f;
    [SerializeField] Collider2D circleCollider;
    [SerializeField] Collider2D boxCollider;
    [SerializeField] Collider2D appleCollider;
    [SerializeField] GameObject maze;

    public Image labyrinthBackground;
    public GameObject labyrinthPlayer;
    public GameObject apple;
    public TextMeshProUGUI textComponent;
    public Player player;

    [SerializeField] State nextState;
    [SerializeField] float waitBetweenChars;
    [SerializeField] float waitBetweenLines;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        StartCoroutine(ChangeMazeColor());
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Move();
        if (circleCollider.IsTouching(boxCollider) && maze.gameObject.GetComponent<SpriteRenderer>().material.color == Color.white)
        {
            this.transform.position = new Vector2(-600, -450);
        }
        if (circleCollider.IsTouching(appleCollider))
        {
            StopCoroutine(ChangeMazeColor());
            labyrinthBackground.enabled = false;
            maze.active = false;
            player.enabled = true;
            player.GetComponent<SpriteRenderer>().enabled = true;
            apple.active = false;
            labyrinthPlayer.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(ShowText(nextState));
        }
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * 2;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * 2;
              
        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPosition, newYPosition);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    IEnumerator ChangeMazeColor()
    {
        int rand = 0;
        while (rand != 7) { 
            rand = Random.Range(0, 15);
            yield return new WaitForSeconds(0.5f);
        }
        maze.gameObject.GetComponent<SpriteRenderer>().material.color = Color.green;
        yield return new WaitForSeconds(6f);
        maze.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        StartCoroutine(ChangeMazeColor());
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
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        labyrinthPlayer.active = false;
    }
}
