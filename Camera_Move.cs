using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public Vector3 move;
    public float speed;
    public GameObject colliderIzq;
    public GameObject colliderDer;
    public GameObject limitIzq;
    public GameObject limitDer;
    public GameObject Pj;
    public GameObject SwordQ;
    public GameObject SwordE;
    public int movementIzq;
    public int movementDer;
    public float swxQ;
    public float swxE;
    public Vector2 leftLimit;




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
        while (transform.position.x <= 0.0f || transform.position.x >= 42.0f)
        {
            if(transform.position.x <= 0.0f)
            {
                transform.position = new Vector3(0, transform.position.y, 0);
            }
            else
            {
                transform.position = new Vector3(42.0f, transform.position.y, 0);
            }
            
        }

        GameObject ColliderDer = GameObject.Find("ColliderDer");
        Colliders_move MovboolDer = ColliderDer.GetComponent<Colliders_move>();
        movementDer = MovboolDer.movement;

        GameObject ColliderIzq = GameObject.Find("ColliderIzq");
        Colliders_move MovboolIzq = ColliderIzq.GetComponent<Colliders_move>();
        movementIzq = MovboolIzq.movement;

        Pj_Script PjScript = Pj.GetComponent<Pj_Script>();

        limitDer = GameObject.Find("LimitDer");
        limitIzq = GameObject.Find("LimitIzq");




        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        move = move.normalized;
        
        if (movementIzq == 1)
        {
            transform.position += move * speed * Time.deltaTime;
        }
        else if (movementDer == -1)
        {
            transform.position += move * speed * Time.deltaTime;
        }

        
        if (PjScript.swordPrepareQ && Input.GetKey(KeyCode.Q))
        {
            SwordQ = GameObject.Find("SwordQ");
            swxQ = SwordQ.transform.position.x;
            transform.position = new Vector3(swxQ, transform.position.y, transform.position.z);
            MovboolDer.movement = 0;
            MovboolIzq.movement = 0;
            Destroy(SwordQ);
        }
        if (PjScript.swordPrepareE && Input.GetKey(KeyCode.E))
        {
            SwordE = GameObject.Find("SwordE");
            swxE = SwordE.transform.position.x;
            transform.position = new Vector3(swxE, transform.position.y, transform.position.z);
            MovboolDer.movement = 0;
            MovboolIzq.movement = 0;
            Destroy(SwordE);
        }
        MovboolDer.movement = 0;
        MovboolIzq.movement = 0;

    }
}
