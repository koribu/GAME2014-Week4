using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    float m_speed;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        Vector2 newPos = new Vector2(x + transform.position.x, y + transform.position.y);
        transform.position = newPos;
        // transform.Translate(new Vector2(x * m_speed, y * m_speed));
    }
}
