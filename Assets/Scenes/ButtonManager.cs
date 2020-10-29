using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //All buttons 
    public void BackToGame(){
        Manager.instance.UnpauseGame();
    }

    public void BeginGame(){
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void QuitGame(){
        // Debug.Log("Game quit.");
        Application.Quit();
    }
}
