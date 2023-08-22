using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static CountTime;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Color[] colorGame = new Color[5];
    [SerializeField] private Color curColor;
    [SerializeField] private Color diffColor;
    [SerializeField] TMP_Text roundtText;
    [SerializeField] public GameObject panelEndGame;
    private int curColorIndex, diffColorIndex, rounds = 1;
    private float difficult;
    

    void Start()
    {
        difficult = 30;
        nextLevel();
    }

    // Update is called once per frame
    public void nextLevel()
    {
        roundtText.text = "Round " + rounds;
        difficult /= 1.05f;
        //chon mau ngau nhien
        curColor = colorGame[Random.Range(0,colorGame.Length-1)];
        diffColorIndex = Random.Range(0, parentObject.transform.childCount);

        diffColor = new Color(curColor.r - (2f/255f * difficult), curColor.g, curColor.b);
        //lay so luong cac obj con roi thay doi mau cua cac obj thong qua vong lap
        int numberChild = parentObject.transform.childCount;
        for(int i =0; i < numberChild; i++)
        {
            Image colorSquare = parentObject.transform.GetChild(i).gameObject.GetComponent<Image>();
            if(i == diffColorIndex)
            {
                colorSquare.color = diffColor;
            }
            else
            {
                colorSquare.color = curColor;

            }

        }
        
    }
    public  void ColorCheck(GameObject obj)
    {
        if (obj == parentObject.transform.GetChild(diffColorIndex).gameObject){
            nextLevel();
            rounds++;
            roundtText.text = "Round " + rounds;
            CountTime.ResetTime();
        }
        else
        {
            EndGame();
        }

        
    }
    public void Update()
    {
        if (CountTime.currentTime <= 0)
        {
            EndGame();
        }
        
    }

    public void EndGame()
    {
        panelEndGame.SetActive(true);
        Debug.Log("End game ");
        currentTime = 0;
        roundtText.text = "End Game\nYour score is " + rounds;

    }
}
