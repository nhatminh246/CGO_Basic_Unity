using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ColorCheck : MonoBehaviour
{
    public GameManager manager;
    public void Check()
    {
        manager.ColorCheck(EventSystem.current.currentSelectedGameObject);
    }
}


