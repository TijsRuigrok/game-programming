using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // clean up objects that are past view
        if (transform.position.z > topBound)
            Destroy(gameObject);
        // log after animal passes player
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
