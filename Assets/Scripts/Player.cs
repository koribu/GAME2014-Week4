using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float m_speed;
    public Boundary boundary;
    public float verticalPosition;

    public float verticalSpeed = 10.0f;
    public bool usingMobileInput = false;

    public Camera camera;

    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        /*   if (Application.platform != RuntimePlatform.Android &&
               Application.platform != RuntimePlatform.IPhonePlayer)
           {
               usingMobileInput = false;
           }
           else
           {
               usingMobileInput = true;
           }*/
        usingMobileInput = Application.platform == RuntimePlatform.Android ||
               Application.platform == RuntimePlatform.IPhonePlayer;

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (usingMobileInput)
            MobileInput();
        else
            ConventionalInput();
        
        Move();

        if(Input.GetKeyDown(KeyCode.K))
        {
            scoreManager.AddPoint(7);
        }
        // transform.Translate(new Vector2(x * m_speed, y * m_speed));
    }

    private void MobileInput()
    {
        foreach(var touch in Input.touches)
        {
           Vector2 destination = new Vector2(camera.ScreenToWorldPoint(touch.position).x, camera.ScreenToWorldPoint(touch.position).y);
           transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * verticalSpeed);
        }
    }

    void SpawnBorder()
    {
        if (transform.position.x >= 3)
            transform.position = new Vector2(-3, transform.position.y);
        else if (transform.position.x < -3)
            transform.position = new Vector2(3, transform.position.y);
    }

    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * m_speed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * m_speed * Time.deltaTime;
        Vector3 newPos = new Vector3(x + transform.position.x, y + transform.position.y);
        transform.position = newPos;
    }
    void Move()
    {
        SpawnBorder();

        CheckBounds();


    }

    void CheckBounds()
    {

        if (transform.position.y > boundary.max)
        {
            transform.position = new Vector2(transform.position.x, boundary.max);
        }
        if (transform.position.y < boundary.min)
        {
            transform.position = new Vector2(transform.position.x, boundary.min);
        }

        /*    float clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
            transform.position = new Vector2(clampedPosition, verticalPosition);*/

        /*  if (transform.position.x > boundary.max)
          {
              transform.position = new Vector2(boundary.max, verticalPosition);
          }
          if (transform.position.x < boundary.min)
          {
              transform.position = new Vector2(boundary.min, verticalPosition);
          }*/
    }
}
