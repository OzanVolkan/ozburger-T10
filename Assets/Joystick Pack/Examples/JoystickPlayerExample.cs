using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public static JoystickPlayerExample instance;
    public bool isMoving;

    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    public Vector3 direction;

    private void Start()
    {
        instance = this;
    }
    public void FixedUpdate()
    {
        if (isMoving)
        {
            direction = floatingJoystick.Direction;

            rb.transform.position += rb.transform.forward * direction.magnitude * speed * Time.fixedDeltaTime;

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.50f, 4.70f), transform.position.y, Mathf.Clamp(transform.position.z, -4.65f, 4.50f));

        }
       
    }
}