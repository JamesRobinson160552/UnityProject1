using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private float verticalMove;
    private float horizontalMove;
    public float speed = 0.05f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Mathf.Sin(transform.eulerAngles.z * 2 * Mathf.PI / 360) * speed;
        horizontalMove = Mathf.Cos(transform.eulerAngles.z *2 * Mathf.PI / 360) * speed;
        gameObject.transform.position += new Vector3(horizontalMove, verticalMove, 0.0f);
        if (gameObject.transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
