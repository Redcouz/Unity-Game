using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders_move : MonoBehaviour
{
    public Vector3 move;
    public float speed;
    public GameObject Pj;
    public GameObject Camera;

    public bool isDer = false;
    public bool isIzq = false;
    public int movement;
    


    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Armature");
        Pj_Script playerScript = thePlayer.GetComponent<Pj_Script>();
        speed = playerScript.speed;
    }

    // Update is called once per frame
    void Update()
    {
           
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        move = move.normalized;
        
        if (Pj.transform.position.x >= transform.position.x && isDer)
        {
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement = 0;
            }
            else
            {
                movement = -1;
                transform.position += move * speed * Time.deltaTime;
            }
        }
        else if (Pj.transform.position.x <= transform.position.x && isIzq)
        {
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movement = 0;
            }
            else
            {
                movement = 1;
                transform.position += move * speed * Time.deltaTime;
            }
        }

        if(isIzq)
        {
            transform.position = Camera.transform.position - new Vector3(5, 0, 0);
        }
        else if (isDer)
        {
            transform.position = Camera.transform.position + new Vector3(5, 0, 0);
        }

    }
}
