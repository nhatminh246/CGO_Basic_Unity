    using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text lap, coins, speed;
    [SerializeField] private GameObject pauseMenu;
    private Rigidbody rb;
/*    private bool moveFoward;
    private bool moveBack;
    private bool moveLeft;
    private bool moveRight;*/
    // Start is called before the first frame update
    void Start()
    {
/*        rb = player.GetComponent<Rigidbody>();
        moveFoward = false;
        moveBack = false;
        moveLeft = false;
        moveRight = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoin();
        UpdateSpeed();
        UpdateLap();
        rb = player.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
/*        Vector3 moveDirection = Vector3.zero;

        if (moveFoward)
            moveDirection += transform.forward;
        if (moveBack)
            moveDirection -= transform.forward;
        if (moveLeft)
            moveDirection -= transform.right;
        if (moveRight)
            moveDirection += transform.right;

        moveDirection.Normalize();
        Vector3 moveForceVector = moveDirection * 20f;
        rb.AddForce(moveForceVector, ForceMode.Force);*/
    }
    void UpdateCoin()
    {
        CoinCollect coinCollect = player.GetComponent<CoinCollect>();
        int coin = coinCollect.coins;
        coins.text = ""+coin;
    }
    void UpdateSpeed()
    {
        Vector3 speedPlayer = player.GetComponent<Rigidbody>().velocity;
        double trueSpeed = Math.Round(speedPlayer.magnitude,3);
        speed.text = "" + trueSpeed;

    }
    void UpdateLap()
    {
        int lapPlayer = player.GetComponent<InteractionManager>().laps;
        lap.text = "" + lapPlayer;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void ReloadGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    /*public void OnPointerDown(string direc)
    {
        switch (direc)
        {
            case "Foward":
                moveFoward = true;
                break;
            case "Back":
                moveBack = true;
                break;
            case "Left":
                moveLeft = true;
                break;
            case "Right":
                moveRight = true;
                break;
        }
    }
    public void OnPointerUp(string direc)
    {
        switch (direc)
        {
            case "Foward":
                moveFoward = false;
                break;
            case "Back":
                moveBack = false;
                break;
            case "Left":
                moveLeft = false;
                break;
            case "Right":
                moveRight = false;
                break;
        }
    }*/
}
