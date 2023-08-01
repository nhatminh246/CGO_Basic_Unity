using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 10f;   

    void Start()
    {
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(horizontalInput * Vector3.right * Time.deltaTime * speed);
        transform.Translate(verticalInput * Vector3.forward * Time.deltaTime * speed);
        
    }
}
