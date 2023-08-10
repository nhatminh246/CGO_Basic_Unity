using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class PlayerControllerManager : MonoBehaviour

{
    private PlayerControllerAuto auto;
    private PlayerControllerManual manual;
    public static int rounds = 0;
    public static int point = 0;
    public static Vector3[] checkPoints = new Vector3[4];


    // Start is called before the first frame update
    void Start()
    {
        checkPoints[0] = new Vector3(126, 0, 114);
        checkPoints[1] = new Vector3(6, 0, 114);
        checkPoints[2] = new Vector3(6, 0, 30);
        checkPoints[3] = new Vector3(126, 0, 30);
        auto = GetComponent<PlayerControllerAuto>();
        manual = GetComponent<PlayerControllerManual>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
        //Bấm phím F để đổi chế độ lái
        if (Input.GetKeyDown(KeyCode.F))
        {
            auto.enabled = !auto.enabled ;
            manual.enabled = !manual.enabled;
        }

    }
}
