using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{

    private GameObject player;
    private GameManager gameManager;
    public GameObject droneShot;
    public float speed = 0.01f;
    public int pointValue = 5;
    private float shootRate = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("shoot", 2.0f, shootRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 16)
        {
            gameObject.transform.position += new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime;
        }
        if (player.transform.position.y > gameObject.transform.position.y)
        {
            gameObject.transform.position += new Vector3(0.0f, speed, 0.0f) * Time.deltaTime;
        }
        else if (player.transform.position.y < gameObject.transform.position.y)
        {
            gameObject.transform.position += new Vector3(0.0f, -speed, 0.0f) * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            gameManager.updateScore(pointValue);
        }
    }

    void shoot()
    {
        if (player.GetComponent<PlayerController>().isAlive)
        {
            Instantiate(droneShot, gameObject.transform.position, droneShot.transform.rotation);
        }
    }
}
