using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float shootRate = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 2.0f, shootRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shoot()
    {
        Instantiate(projectilePrefab, gameObject.transform.position, projectilePrefab.transform.rotation);
    }

}
