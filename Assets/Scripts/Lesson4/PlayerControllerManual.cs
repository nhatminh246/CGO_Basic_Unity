using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerControllerManager;

public class PlayerControllerManual : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float verticalInput, horizontalInput;
    [SerializeField]
    private float speed = 30f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Dùng phím mũi tên trên bàn phím để di chuyển 
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + transform.forward * speed * verticalInput * Time.deltaTime;
        transform.position = transform.position + transform.right * speed * horizontalInput * Time.deltaTime;

        Vector3 direction = checkPoints[point] - transform.position;
        float road = direction.magnitude;

        if (road > 2f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            if (point == checkPoints.Length - 1)
            {
                point = 0;
                rounds++;
                Debug.Log("Round :" + rounds);
            }
            else point++;

        }



    }
}
