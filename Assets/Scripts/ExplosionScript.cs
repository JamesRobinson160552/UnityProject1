using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public float horizontalInput;
    private float rotationSpeed = -0.3f;
    private float verticalSpeed = 0.03f;
    private float verticalMove;
    private float maxRotation = 0.65f;
    private float ceiling = 18.0f;
    public GameObject gameManager;
    public ParticleSystem explosionParticle;
    public AudioClip explosionSound;
    private AudioSource explosionAudio;

    // Start is called before the first frame update
    void Start()
    {
        explosionAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Follow player while game is active
        if (gameManager.GetComponent<GameManager>().gameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            gameObject.transform.Rotate(0.0f, 0.0f, horizontalInput * rotationSpeed);
            //Move vertically
            verticalMove = Mathf.Sin(transform.eulerAngles.z * 2 * Mathf.PI / 360) * verticalSpeed;
            gameObject.transform.position += new Vector3(0.0f, verticalMove, 0.0f);

            //Dont exceed ceiling limit
            if (gameObject.transform.position.y >= ceiling)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, ceiling, gameObject.transform.position.z);
            }
        }
    }

    public void explode()
    {
        explosionParticle.Play();
        explosionAudio.PlayOneShot(explosionSound, 1.0f);
    }
}
