using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the object collides with another object with a collider, destroy the object
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
