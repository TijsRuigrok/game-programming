using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Field Declarations

    public GameObject player;
    private Vector3 offset = new Vector3(0, 60, 25);

    #endregion

    void Update()
    {
        if(player != null)
            transform.position = player.transform.position + offset;
    }
}
