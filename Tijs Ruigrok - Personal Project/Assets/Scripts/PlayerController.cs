using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xRange = 20;
    public float zRange = 40;
    public ParticleSystem dirtParticle;

    private float speed = 20f;
    private float verticalInput;
    private float horizontalInput;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        dirtParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void ConstrainPlayer()
    {
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        else if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        else if (transform.position.z < -zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);

        else if (transform.position.z > zRange)
        {
            Debug.Log("Victory!");
            Destroy(gameObject);
            //transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
}
