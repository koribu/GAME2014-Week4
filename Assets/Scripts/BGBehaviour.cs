using UnityEngine;

public class BGBehaviour : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(0, verticalSpeed *Time.deltaTime, 0);
    }

    private void CheckBounds()
    {
        if (transform.position.y < boundary.min)
            ResetBG();
    }
    private void ResetBG()
    {
        transform.position = new Vector2(0, boundary.max);
    }
}
