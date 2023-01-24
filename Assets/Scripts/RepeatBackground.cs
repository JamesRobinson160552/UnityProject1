using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPosition;
    public GameObject player;
    private float repeatWidth;
    public float speed = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().isAlive)
        {
            transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
            if (transform.position.x < startPosition.x - repeatWidth)
            {
                transform.position = startPosition;
            }
        }
    }
}
