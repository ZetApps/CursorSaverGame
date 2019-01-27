using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;


public class UIInputController : MonoBehaviour
{
    
    
    public void LoadMenu()=>SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);

    public void RestartGame()
    {
        StaticLevelData.currentLevel = 0;
        StaticLevelData.score = 0;
        StaticLevelData.isDead = false;
        GameObject.FindGameObjectWithTag("ContinButton").SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueGame()
    {
        if (!StaticLevelData.isDead)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("Невозможно продолжить, так как курсор погиб");
        }
    }
}
