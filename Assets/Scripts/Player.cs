using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] bool moveable;
    [SerializeField] bool correctMovement;
    [SerializeField] bool deltaTimeExists;
    [SerializeField] bool usingSpeed;
    [SerializeField] float speed = 1f;
    float padding = 0.5f;
    float xMin;
    float xMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        //Ovo je za dodavanje gravitacije
        //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        if (moveable == true)
        {
            var deltaX = 0.0f;
            if(correctMovement == false)
            {
                deltaX = -(Input.GetAxis("Horizontal"));
            }
            else
            {
                deltaX = Input.GetAxis("Horizontal");
                if(usingSpeed == true)
                {
                    deltaX *= speed;
                    if(deltaTimeExists == true)
                    {
                        deltaX *= Time.deltaTime;
                    }
                }
            }
            var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
            transform.position = new Vector2(newXPosition, transform.position.y);
        }
    }

    public void EnableMovement()
    {
        moveable = true;
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    private void AccountForSpeed()
    {
        usingSpeed = true;
    }

    private void EnableDeltaTime()
    {
        deltaTimeExists = true;
    }
}
