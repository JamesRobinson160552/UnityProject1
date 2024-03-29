using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    private float rotationSpeed = -45.0f;
    private float verticalSpeed = 15.0f;
    private float verticalMove;
    private float maxRotation = 0.65f;
    private float ceiling = 19.0f;
    private float shootCooldown = 1.6f;
    public float timeSinceShot = 1.0f;
    public bool isAlive = true;
    public GameObject projectilePrefab;
    public GameManager gameManager;
    public AudioSource playerAudio;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            rotate();
            moveVertically();

            //Launch projectile
            if (Input.GetKeyDown(KeyCode.Space) && timeSinceShot > shootCooldown)
            {
                shootProjectile();
            }

            timeSinceShot += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("EnemyProjectile"))
        {
            isAlive = false;
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }

    void shootProjectile()
    {
        Instantiate(projectilePrefab, gameObject.transform.position, gameObject.transform.rotation);
        timeSinceShot = 0;
        playerAudio.PlayOneShot(shootSound, 1.0f);
    }

    void rotate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        gameObject.transform.Rotate(0.0f, 0.0f, horizontalInput * rotationSpeed * Time.deltaTime);
    }

    void moveVertically()
    {
        //Move vertically
        verticalMove = Mathf.Sin(transform.eulerAngles.z * 2 * Mathf.PI / 360) * verticalSpeed;
        gameObject.transform.position += new Vector3(0.0f, verticalMove, 0.0f) * Time.deltaTime;

        //Dont exceed ceiling limit
        if (gameObject.transform.position.y >= ceiling)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, ceiling, gameObject.transform.position.z);
        }
    }

}
