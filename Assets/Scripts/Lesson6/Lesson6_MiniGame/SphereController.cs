using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private int point = 0;
    private Rigidbody rb;
    public TextMesh winText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputHori = Input.GetAxis("Horizontal");
        float inputVerti = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(inputHori, 0, inputVerti) ;
        rb.AddForce(move);
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            point++;
            Debug.Log("Point : " + point);
            Destroy(collision.gameObject);
        }
        if(point == 10)
        {
            winText.text = "You Win";
        }
    }
}
