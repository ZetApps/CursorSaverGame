using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public bool alive;
    
    
    private Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Move();
        }
        else
        {
            Dead();
        }
    }


    private void Move()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -1;
        transform.position = Vector3.MoveTowards(transform.position,pos,speed*Time.deltaTime);
    }

    private void Dead()
    {
        StaticLevelData.score += 1;
        Destroy(gameObject);
    }


}
