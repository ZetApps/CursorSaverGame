using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Bootstrap : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject HiddenMenu;
    [SerializeField] private Text Score;
    [SerializeField] private Camera mainCamera;
    
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float EnemyDefaultSize;
    [SerializeField] private float EnemyMaxSpeed;
    [SerializeField] private float EnemyDecreseaseSpeedBySize;
    [SerializeField] private float EnemySizeChange;
    
    [SerializeField] private Color cameraBgColor;
    
    [SerializeField] private int InitialEnemyCount;
    [SerializeField] private int EnemyIncreaseByLevel;


    private int currentEnemyCount;
    private GameObject[] enemyList;
    
    void Awake()
    {
        Time.timeScale = 1;
        HiddenMenu.SetActive(false);
    }

    void Start(){
        if (mainCamera != null)mainCamera.backgroundColor = cameraBgColor;
        for (int i = 0; i < InitialEnemyCount+(EnemyIncreaseByLevel*StaticLevelData.currentLevel); i++) SpawnEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        
        Score.text = StaticLevelData.score.ToString();
        
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StaticLevelData.currentLevel += 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        if (Input.GetKeyDown("escape"))
            if (!HiddenMenu.activeSelf)
            {
                HiddenMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                HiddenMenu.SetActive(false);
                Time.timeScale = 1;
            }
    }


    private void SpawnEnemy()
    {
        float posX = 0f;
        float posY = 0f;
        //while ((posX >= -10) && (posX <= 10))
        posX = Random.Range(-12f, 12f);
        while ((posY >= -6) && (posY <= 6)) posY = Random.Range(-8f, 8f);

        Vector3 pos = new Vector3(posX, posY, 10);
        GameObject enemy = Instantiate(Enemy, pos, Quaternion.identity);
        int size = Mathf.RoundToInt(Random.Range(0, 5));
        enemy.GetComponent<Transform>().localScale=new Vector3(EnemyDefaultSize+(EnemySizeChange*size),EnemyDefaultSize+(EnemySizeChange*size),1);
        enemy.GetComponent<EnemyMovement>().speed = EnemyMaxSpeed-(EnemyDecreseaseSpeedBySize*size);
    }
}
