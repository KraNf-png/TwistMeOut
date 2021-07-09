using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{

    private Rigidbody rb;
    public float ForceValue = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -20, 0);

        rb = GetComponent<Rigidbody>();

        SwapObject.SwipeEvent += OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        var dir =
        direction == Vector2.up ? Vector3.forward :
        direction == Vector2.down ? Vector3.back : (Vector3)direction;

        Move(dir);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Move(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.D))
            Move(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.W))
            Move(Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.S))
            Move(Vector3.back);
    }

    private void Move(Vector3 direction)
    {
        rb.AddRelativeForce(direction * ForceValue);
    }

}