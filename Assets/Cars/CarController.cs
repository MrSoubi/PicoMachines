using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Vector2 direction;
    public bool isAccelerating;
    public float maxSpeed = 5;

    public float Velocity => rb.velocity.magnitude;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();

        if (isAccelerating)
        {
            //rb.AddForce(direction, ForceMode2D.Force);
            rb.AddForceAtPosition(direction, transform.position, ForceMode2D.Force);
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void GetInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        isAccelerating = Input.GetKey(KeyCode.Space);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 2);
    }
}
