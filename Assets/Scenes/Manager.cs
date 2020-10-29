using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public static Manager instance;

    private Manager() {}

    void Awake()
    {
        if(instance)
            Destroy(gameObject);
        else
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(Time.timeScale == 1)
                PauseGame();
        }
    
    }

    void PauseGame(){
        Time.timeScale = 0;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }

    public void UnpauseGame(){
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

}
