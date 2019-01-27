using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    public GameObject HiddenMenu;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyMovement>().alive = false;
        }

        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            StaticLevelData.isDead = true;
            HiddenMenu.SetActive(true);
        }
    }
}
