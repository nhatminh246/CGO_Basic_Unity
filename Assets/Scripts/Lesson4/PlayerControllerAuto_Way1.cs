using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerControllerManager_Way1;
public class PlayerControllerAuto_Way1 : MonoBehaviour
{
    [SerializeField]
    private float speed = 25;
    public static Vector3[] checkPoints = new Vector3[4];

    // Start is called before the first frame update
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

        if (road > 1f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            Vector3 movement = direction.normalized * speed * Time.deltaTime;
            transform.position += movement;
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