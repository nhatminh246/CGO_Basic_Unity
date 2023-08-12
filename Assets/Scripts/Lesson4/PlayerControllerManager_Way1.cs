using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class PlayerControllerManager_Way1 : MonoBehaviour

{
    private PlayerControllerAuto_Way1 auto;
    private PlayerControllerManual_Way1 manual;
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
        auto = GetComponent<PlayerControllerAuto_Way1>();
        manual = GetComponent<PlayerControllerManual_Way1>();

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
