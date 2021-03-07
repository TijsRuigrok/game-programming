using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Field Declarations

    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset = new Vector3(0, 60, 25);

    private Transform playerTransform;

    #endregion

    void LateUpdate()
    {
        if (playerTransform != null)
            SmoothCameraFollow();
    }

    public void SetTarget(Transform target)
    {
        playerTransform = target;
    }

    private void SmoothCameraFollow()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
