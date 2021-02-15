using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public enum Direction {Left, Right};
    public Direction direction;
    private float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Direction.Left)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        else if (direction == Direction.Right)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
