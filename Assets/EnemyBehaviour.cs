using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundary horizontalBoundry;
    public Boundary verticalBoundry;

    public float horizontalSpeed = 4;
    public Boundary horizontalSpeedRange;

    // Start is called before the first frame update
    void Start()
    {
        var RandomXPosition = Random.RandomRange(horizontalBoundry.min, horizontalBoundry.max);
        var RandomYPosition = Random.RandomRange(verticalBoundry.min, verticalBoundry.max);

        horizontalSpeedRange.min = Random.Range(0.5f, 2.0f);
        horizontalSpeedRange.min = Random.Range(2f, 6f);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);

        transform.position = new Vector3(RandomXPosition, RandomYPosition, 0);
    }

    // Update is called once per frame,
    void Update()
    {
        var horizontalLenght = horizontalBoundry.max - horizontalBoundry.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed,horizontalLenght) - horizontalBoundry.max,transform.position.y,transform.position.z);
    }
}
