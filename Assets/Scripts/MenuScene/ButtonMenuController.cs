using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenuController : MonoBehaviour
{
    public string NewGameSceneName;
    public LoadSceneMode NewGameSceneMode;


    public void LoadLevel()
    {
        StaticLevelData.currentLevel = 0;
        StaticLevelData.score = 0;
        StaticLevelData.isDead = false;
        SceneManager.LoadScene(NewGameSceneName,NewGameSceneMode);   
    }

    public void ApplicationExit() => Application.Quit(0);
}
