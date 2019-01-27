using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    [SerializeField] private GameObject HiddenMenu;
    private Vector3 pos;
    
    
    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -1;
        transform.position = pos;   
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            StaticLevelData.isDead = true;
            Debug.Log("Enemy find you...");
            HiddenMenu.SetActive(true);
        }
    }
}
