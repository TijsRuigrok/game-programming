using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 60, 25);
    Vector3 resetPos = new Vector3(0, 30, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            transform.position = resetPos;
        else
            transform.position = player.transform.position + offset;
    }
}
