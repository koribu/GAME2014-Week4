using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float m_speed;
    public Boundary boundary;
    public float verticalPosition;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SpawnBorder();

        CheckBounds();
        // transform.Translate(new Vector2(x * m_speed, y * m_speed));
    }

    void SpawnBorder()
    {
        if (transform.position.x >= 3)
            transform.position = new Vector2(-3, transform.position.y);
        else if (transform.position.x < -3)
            transform.position = new Vector2(3, transform.position.y);
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * m_speed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * m_speed * Time.deltaTime;

        Vector2 newPos = new Vector2(x + transform.position.x, y + transform.position.y);
        transform.position = newPos;
    }

    void CheckBounds()
    {
        
        if(transform.position.y > boundary.max)
        {
            transform.position = new Vector2(transform.position.x, boundary.max);
        }
        if (transform.position.y < boundary.min)
        {
            transform.position = new Vector2(transform.position.x, boundary.min);
        }

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
