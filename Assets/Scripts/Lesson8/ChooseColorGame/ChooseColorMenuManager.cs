using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseColorMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
