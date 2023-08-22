using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int damaged = 0;
    [SerializeField] private int fuel = 0;
    [SerializeField] private int capacity = 100;
    public int laps = 0;

    //private Rigidbody rb;
    public List<GameObject> lstItem = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "RedFuel":
                fuel += 25;
                if (fuel >= capacity) fuel = capacity;                
                Debug.Log("Fuel: " + fuel);
                DisableItem(other.gameObject, lstItem);

                break;
            case "BlueFuel":
                fuel += 10;
                if (fuel >= capacity) fuel = capacity;
                Debug.Log("Fuel: " + fuel);
                DisableItem(other.gameObject, lstItem);


                break;
            case "Gift":
                damaged -= 30;
                if (damaged < 0) damaged = 0;
                Debug.Log("Damaged: " + damaged);

                DisableItem(other.gameObject, lstItem);


                break;
            case "UltraGift":
                damaged = 0;      
                Debug.Log("Damaged: " + damaged);

                DisableItem(other.gameObject, lstItem);

                break;
            

            case "Finish":
                laps++;
                Debug.Log("Laps: "+laps);
                foreach(GameObject item in lstItem)
                {
                    item.SetActive(true);
                }
                lstItem.Clear();
                break;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            damaged += 5;
            Debug.Log("Damaged: " + damaged);
            if (damaged >= 100) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }

    private void DisableItem(GameObject gameObject, List<GameObject> lst)
    {

        gameObject.SetActive(false);
        lst.Add(gameObject);
    }


    void Start()
    {
        Debug.Log("Race Start!!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
