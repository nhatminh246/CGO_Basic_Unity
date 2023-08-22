using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider backLeftWheel;
    [SerializeField] private WheelCollider backRightWheel;

    [SerializeField] private float maxSteerAngle = 30f;

    [SerializeField] private float carForce = 1000f;
    [SerializeField] private float brakeForce = 4000f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        float angle = maxSteerAngle * inputHorizontal;
        float force = carForce * inputVertical;

        frontLeftWheel.steerAngle = angle;
        frontRightWheel.steerAngle = angle;

        backLeftWheel.motorTorque = force;
        backRightWheel.motorTorque = force;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            frontLeftWheel.brakeTorque = brakeForce;
            frontRightWheel.brakeTorque = brakeForce;
            backLeftWheel.brakeTorque = brakeForce;
            backRightWheel.brakeTorque = brakeForce;
        }
        else
        {
            frontLeftWheel.brakeTorque = 0;
            frontRightWheel.brakeTorque = 0f;
            backLeftWheel.brakeTorque = 0f;
            backRightWheel.brakeTorque = 0f;
        }
    }
}
