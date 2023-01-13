using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootUp : MonoBehaviour
{

    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move up, destroy if higher than 20
        gameObject.transform.position += new Vector3(0.0f, speed, 0.0f);
        if (gameObject.transform.position.y > 20)
        {
            Destroy(gameObject);
        }
    }
}
