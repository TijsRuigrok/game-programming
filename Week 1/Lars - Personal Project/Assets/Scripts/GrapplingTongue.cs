using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingTongue : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    public LayerMask hookable;
    public Transform tongueTip, tongueCamera;
    float maxDistance = 100f;
    private SpringJoint springJoint;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            StartTongue();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReleaseTongue();
        }
    }

    private void LateUpdate()
    {
        DrawTongue();
    }

    // method to call whenever we want to tongue an object
    void StartTongue()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(tongueCamera.position, tongueCamera.forward, out raycastHit, maxDistance, hookable))
        {
            grapplePoint = raycastHit.point;
            springJoint = player.gameObject.AddComponent<SpringJoint>();
            springJoint.autoConfigureConnectedAnchor = false;
            springJoint.connectedAnchor = grapplePoint;

            float distanceFromGrapplePoint = Vector3.Distance(player.position, grapplePoint);

            springJoint.maxDistance = distanceFromGrapplePoint * 0.75f;
            springJoint.minDistance = distanceFromGrapplePoint * 0.25f;

            //grappleTongue tweak settings
            springJoint.spring = 5f;
            springJoint.damper = 10f;
            springJoint.massScale = 5f;

            lineRenderer.positionCount = 2;
        }
    }

    void DrawTongue()
    {
        if (!springJoint)
            return;

        lineRenderer.SetPosition(0, tongueTip.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    void ReleaseTongue()
    {   
        //positionCount is in control of the number of vertices, 0 is effectively absent
        lineRenderer.positionCount = 0;
        Destroy(springJoint);
    }
}
