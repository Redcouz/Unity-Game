using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    private Vector3 move;
    public float speed;
    private bool attack = false;
    private GameObject Pj;
    private GameObject SpawnEnemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerWall")
        {
            speed = 0;
            attack = true;
        }

        if (collision.gameObject.tag == "hitBox")
        {
            Destroy(gameObject, 0.2f);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerWall")
        {
            speed = 5;
            attack = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "SwordQ" || collision.gameObject.tag == "SwordE")
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Pj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= Pj.transform.position.x)
        {
            if (speed < 0)
            {
                speed *= -1;
            }
            move = new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += move;
        }
        else if (transform.position.x >= Pj.transform.position.x)
        {
            if (speed > 0)
            {
                speed *= -1;
            }
            move = new Vector3(speed * Time.deltaTime, 0, 0);
            transform.position += move;
        }

        if (attack)
        {
            print("Attack");
        }

       
    }
}
