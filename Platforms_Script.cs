using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms_Script : MonoBehaviour
{
    public Pj_Script Pj;

    public bool playerOnColl;


    public int levelPlat;
    public bool readyForJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && collision.gameObject.GetComponent<Pj_Script>().jump == levelPlat - 1)
        {
            readyForJump = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        Pj = GameObject.FindGameObjectWithTag("Player").GetComponent<Pj_Script>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerOnColl = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerOnColl = false;
        }
        if (collision.gameObject.tag == "Player")
        {
            readyForJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(gameObject.name + " " + Pj.transform.position.y + " " + transform.position.y);
        if (Pj.transform.position.y >= gameObject.GetComponent<Collider2D>().offset.y && !Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }


    }
}
