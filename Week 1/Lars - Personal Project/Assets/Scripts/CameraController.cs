using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseSensitivity = 1.4f;
    public Transform player, playerView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotationX = mouseX * mouseSensitivity;
        float rotationY = mouseY * mouseSensitivity;

        Vector3 rotationPlayer = player.transform.rotation.eulerAngles;
        Vector3 rotationPlayerView = playerView.transform.rotation.eulerAngles;

        rotationPlayerView.x -= rotationY;
        rotationPlayer.y += rotationX;

        playerView.rotation = Quaternion.Euler(rotationPlayerView);
        player.rotation = Quaternion.Euler(rotationPlayer);
    }
}
