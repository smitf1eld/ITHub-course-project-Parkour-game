using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    private readonly int _sceneNumber = 1;
    
    public void SwitchScene()
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
