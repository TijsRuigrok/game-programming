using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded;
    private float jumpForce = 5f;
    private float speedAcceleration = 200f;
    private float speedCap = 7f;
    public Vector3 playerVelocity;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // we need the velocity of the player to enforce a capped velocity while grounded
        // when the capped velocity is reached the player should still be able to add velocity in the inverse direction
        playerVelocity = playerRb.velocity;
        UpdatePlayerMovement(horizontalInput, verticalInput);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void UpdatePlayerMovement(float horizontalInput, float verticalInput)
    {

        if (playerVelocity.magnitude > speedCap)
        {
            playerVelocity = playerVelocity.normalized * speedCap;
        }
        else
        {
            playerRb.AddForce(transform.right * speedAcceleration * horizontalInput);
            playerRb.AddForce(transform.forward * speedAcceleration * verticalInput);
        }

        // when moving in X and Z axis the combined movement will be greater than the current cap
        // moving diagonally is fun (goldeneye for ex.) but it should be capped to a more sensible speed
    }
}
