using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float verticalInput { get { return Input.GetAxis("Vertical"); } }
    float horizontalInput { get { return Input.GetAxis("Horizontal"); } }

    public float speed = 10;
    Vector3 movement; 
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = horizontalInput;
        movement.y = verticalInput;
        transform.position = transform.position + (movement * Time.deltaTime * speed);
    }
}
