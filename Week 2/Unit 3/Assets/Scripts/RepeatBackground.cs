using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeadWith;
    // Start is called before the first frame update
    void Start()
    {
        repeadWith = GetComponent<BoxCollider>().size.x / 2 ;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeadWith)
            transform.position = startPos;
    }
}
