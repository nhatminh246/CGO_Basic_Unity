using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Way2_Enum : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int point = 0;
    [SerializeField] private float speed = 30f;
    [SerializeField] private Vector3[] checkPoints = new Vector3[4];
    [SerializeField] private float verticalInput, horizontalInput;

    enum DriveMode
    {
        Auto,
        Manual
    }
    private DriveMode driveMode = DriveMode.Auto;
    void Start()
    {
        checkPoints[0] = new Vector3(126, 0, 114);
        checkPoints[1] = new Vector3(6, 0, 114);
        checkPoints[2] = new Vector3(6, 0, 30);
        checkPoints[3] = new Vector3(126, 0, 30);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = checkPoints[point] - transform.position;
        float road = direction.magnitude;
        if (driveMode == DriveMode.Auto)
        {
            if (road > 1f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
                transform.position = Vector3.MoveTowards(transform.position, checkPoints[point], speed * Time.deltaTime);
            }
            else
            {
                ChangePoint(ref point, checkPoints);

            }
        }
        else if(driveMode == DriveMode.Manual)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            transform.position = transform.position + transform.forward * speed * verticalInput * Time.deltaTime;
            transform.position = transform.position + transform.right * speed * horizontalInput * Time.deltaTime;

            

            if (road > 2f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
            else
            {
                ChangePoint(ref point, checkPoints);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchDriveMode(ref driveMode);
        }


    }
    private void SwitchDriveMode(ref DriveMode driveMode)
    {
        switch (driveMode)
        {
            case DriveMode.Auto:
                driveMode = DriveMode.Manual;
                break;
            case DriveMode.Manual:
                driveMode = DriveMode.Auto;
                break;
        }
    }
    private void ChangePoint(ref int point, Vector3[] arr)
    {
        if (point == arr.Length - 1)
        {
            point = 0;
        }
        else point++;
    }
}
