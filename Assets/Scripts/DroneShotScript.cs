using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneShotScript : MonoBehaviour
{

    public float speed = -0.08f;
    public int leftBound = -20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
        if (gameObject.transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}