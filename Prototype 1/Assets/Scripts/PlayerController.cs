using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0;
     [SerializeField] private float speed = 0f;
    [SerializeField] private float turnSpeed = 25;
    private float turnValue = 0;
    private float accelValue = 0;
    private Rigidbody rb;
    [SerializeField] GameObject COM;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] List<WheelCollider> allWheels;
    int wheelsOnGround = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = COM.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // learn code
        // transform.Translate(0, 0, 1);
        // transform.Translate(Vector3.forward);


        turnValue = Input.GetAxis("Horizontal");
        accelValue = Input.GetAxis("Vertical");
        if (isGrounded())
        {
            // Move vehicle forward
            // transform.Translate(Vector3.forward * Time.deltaTime * speed * accelValue);
            rb.AddRelativeForce(Vector3.forward * accelValue * horsePower);

            // learn code
            // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * turnValue);

            // turn vehicle
            transform.Rotate(Vector3.up, turnValue * Time.deltaTime * turnSpeed);

            // calculate speed
            speed = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f);
            speedometerText.text = ("Speed: " + speed + "Km/h");
        }
        

    }

    bool isGrounded()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
