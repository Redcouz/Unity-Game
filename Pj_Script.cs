using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using System;

public class Pj_Script : MonoBehaviour
{
    //Declare Variables
    public Vector3 moveX;
    private int directionX;
    public float speed;
    public int jump = 0;
    public float posX;
    public float posY;
    public float posZ;
    public int life;
    public bool canMove = true;
    public bool twoHanded;
    public bool canAtack = false;
    public bool armThrowQ = false;
    public bool hasArmQ = false;
    public bool oneHanded = false;
    public bool armThrowE = false;
    public bool hasArmE = false;
    public bool enPlat = false;
    public bool onFloor = false;
    public bool canJump = false;
    public bool onAnim = false;



    public Rigidbody2D rb;





    //Declare variables that has been modiefied in Sword script
    public bool swordPrepareQ = false;
    public bool swordPrepareE = false;


    //Declare Game objects that takes the instantiate sword
    private GameObject swordInstQ;
    private GameObject swordInstE;




    //Declare variable to flip sword
    public int dir = 0;

    //Declare Variable for prefab sword

    public GameObject swordQ;
    public GameObject swordE;

    public GameObject[] Platforms = new GameObject[3];
    public GameObject[] HitBoxs = new GameObject[2];


    //Declare Variable Armature to use for animation
    private UnityArmatureComponent armatureComponent = null;

    public float jumpStr;
    public float dropForce;
    private bool isGetting;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onFloor = true;
            Platforms = GameObject.FindGameObjectsWithTag("plat1");
            Platforms_Script PlatformsScript0 = Platforms[0].GetComponent<Platforms_Script>();
            Platforms_Script PlatformsScript1 = Platforms[1].GetComponent<Platforms_Script>();
            Platforms_Script PlatformsScript2 = Platforms[2].GetComponent<Platforms_Script>();
            var BxCol0 = Platforms[0].GetComponent<BoxCollider2D>();
            var BxCol1 = Platforms[1].GetComponent<BoxCollider2D>();
            var BxCol2 = Platforms[2].GetComponent<BoxCollider2D>();

            BxCol0.isTrigger = true;
            BxCol1.isTrigger = true;
            BxCol2.isTrigger = true;

            jump = 0;
        }
        else
        {
            onFloor = false;
        }
    }
    //public int points;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        //Put The animation in Idle1
        armatureComponent = GetComponent<UnityArmatureComponent>();
        armatureComponent.animation.Play("Idle1");

    }

    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        HitBoxs = GameObject.FindGameObjectsWithTag("hitBox");

        //Animation Control
        if (canMove)
        {
            moveX = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            moveX = moveX.normalized;

            transform.position = transform.position + moveX * speed * Time.deltaTime;
        }

        //Check if the animation is completed
        if (armatureComponent.animation.isCompleted)
        {
            canMove = true;
            onAnim = false;
            isGetting = false;
            HitBoxs[0].GetComponent<Collider2D>().offset = new Vector3 (0,10000,0);
            HitBoxs[1].GetComponent<Collider2D>().offset = new Vector3(0, 10000, 0);

            //Check what idle use
            if (twoHanded)
            {
                canAtack = true;
                armatureComponent.animation.FadeIn("Idle2", -1, -1);

            }
            else if (oneHanded)
            {
                canAtack = true;
                armatureComponent.animation.FadeIn("Idle3", -1, -1);


            }
            else
            {
                armatureComponent.animation.FadeIn("Idle1", -1, -1);


            }
        }
      
        //Do the momevent code
        //Animation Control for moving
        if (Input.GetKeyDown(KeyCode.RightArrow) && directionX != 1 && canMove)
        {
            if (twoHanded)
            {
                canAtack = true;
                armatureComponent.animation.FadeIn("Walk2", -1, -1);
                directionX = 1;
                armatureComponent.armature.flipX = true;
            }
            else if (oneHanded)
            {
                canAtack = true;
                armatureComponent.animation.FadeIn("Walk3", -1, -1);
                directionX = 1;
                armatureComponent.armature.flipX = true;
            }
            else
            {
                armatureComponent.animation.FadeIn("Walk1", -1, -1);
                directionX = 1;
                armatureComponent.armature.flipX = true;
            }

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && directionX != -1 && canMove)
        {
            if (twoHanded)
            {
                canAtack = true;
                armatureComponent.animation.FadeIn("Walk2", -1, -1);
                directionX = -1;
                armatureComponent.armature.flipX = false;
            }
            else if (oneHanded)
            {
                canAtack = true;
                armatureComponent.animation.FadeIn("Walk3", -1, -1);
                directionX = -1;
                armatureComponent.armature.flipX = false;
            }
            else
            {
                armatureComponent.animation.FadeIn("Walk1", -1, -1);
                directionX = -1;
                armatureComponent.armature.flipX = false;
            }

        }

        else if (Input.GetAxisRaw("Horizontal") == 0 && directionX != 0)
        {
            if (twoHanded)
            {
                armatureComponent.animation.FadeIn("Idle2", -1, -1);
                directionX = 0;
            }
            else if (oneHanded)
            {
                armatureComponent.animation.FadeIn("Idle3", -1, -1);
                directionX = 0;
            }
            else
            {
                armatureComponent.animation.FadeIn("Idle1", -1, -1);
                directionX = 0;


            }
        }
        //To flip the sword ---- No funciona
        if (armatureComponent.armature.flipX)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }

        if (Input.GetKey(KeyCode.Alpha1) && !twoHanded && !oneHanded && !swordPrepareQ && !swordPrepareE)
        {
            canMove = false;
            twoHanded = true;
            armatureComponent.animation.FadeIn("Invocation", -1, 1);
        }

        if (Input.GetKey(KeyCode.W) && (twoHanded || oneHanded) && canAtack)
        {
            if (twoHanded)
            {
                canAtack = false;
                armatureComponent.animation.FadeIn("Atack1", -1, 1);
                if (armatureComponent.armature.flipX)
                {
                    HitBoxs[0].GetComponent<Collider2D>().offset = new Vector3(1.5f, 1.3f,0);
                }
                else
                {
                    HitBoxs[0].GetComponent<Collider2D>().offset = new Vector3(-1.5f, 1.3f, 0);
                }

            }
            else if (oneHanded)
            {
                canAtack = false;
                armatureComponent.animation.FadeIn("Atack2", -1, 1);
            }
        }

        if (armThrowQ)
        {
            swordInstQ = Instantiate(swordQ, transform.position + new Vector3(2 * dir, 1.5f, 0), Quaternion.Euler(0, 0, 0));
            swordInstQ.name = "SwordQ";
            var swordComp = swordInstQ.GetComponent<Sward_Script>();
            swordComp.speed = 20 * dir;
            armThrowQ = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && (twoHanded || oneHanded) && canAtack && !hasArmQ)
        {
            if (oneHanded)
            {
                oneHanded = false;
                canAtack = false;
                hasArmQ = true;
                armThrowQ = true;
                armatureComponent.animation.FadeIn("ThrowSword1Handed", -1, 1);
            }
            else
            {
                hasArmQ = true;
                twoHanded = false;
                armThrowQ = true;
                armatureComponent.animation.FadeIn("ThrowSword2Handed", -1, 1);
                oneHanded = true;
            }

        }
        if (hasArmQ && Input.GetKeyDown(KeyCode.Q) && swordPrepareQ && swordInstQ != null)
        {
            if (oneHanded)
            {
                isGetting = true;
                transform.position = new Vector3(swordInstQ.transform.position.x, swordInstQ.transform.position.y, transform.position.z);
                hasArmQ = false;
                swordPrepareQ = false;
                armatureComponent.animation.FadeIn("GetSword2Handed", -1, 1);
                oneHanded = false;
                twoHanded = true;
            }
            else
            {
                isGetting = true;
                transform.position = new Vector3(swordInstQ.transform.position.x, swordInstQ.transform.position.y, transform.position.z);
                swordPrepareQ = false;
                armatureComponent.animation.FadeIn("GetSword1Handed", -1, 1);
                oneHanded = true;
                twoHanded = false;
                hasArmQ = false;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------
        if (armThrowE)
        {
            swordInstE = Instantiate(swordE, transform.position + new Vector3(2 * dir, 1.5f, 0), Quaternion.Euler(0, 0, 0));
            swordInstE.name = "SwordE";
            var swordCompE = swordInstE.GetComponent<Sward_Script>();
            swordCompE.speed = 20 * dir;
            armThrowE = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && (twoHanded || oneHanded) && canAtack && !hasArmE)
        {
            if (oneHanded)
            {
                oneHanded = false;
                canAtack = false;
                hasArmE = true;
                armThrowE = true;
                armatureComponent.animation.FadeIn("ThrowSword1Handed", -1, 1);
            }
            else
            {
                hasArmE = true;
                twoHanded = false;
                armThrowE = true;
                armatureComponent.animation.FadeIn("ThrowSword2Handed", -1, 1);
                oneHanded = true;
            }

        }
        if (hasArmE && Input.GetKeyDown(KeyCode.E) && swordPrepareE && swordInstE != null)
        {
            if (oneHanded)
            {
                isGetting = true;
                transform.position = new Vector3(swordInstE.transform.position.x, swordInstE.transform.position.y, transform.position.z);
                hasArmE = false;
                swordPrepareE = false;
                armatureComponent.animation.FadeIn("GetSword2Handed", -1, 1);
                oneHanded = false;
                twoHanded = true;
            }
            else
            {
                isGetting = true;
                transform.position = new Vector3(swordInstE.transform.position.x, swordInstE.transform.position.y, transform.position.z);
                swordPrepareE = false;
                armatureComponent.animation.FadeIn("GetSword1handed", -1, 1);
                oneHanded = true;
                twoHanded = false;
                hasArmE = false;
            }
        }
        CharacterJump();
        CharacterFall();

    }

    private void CharacterJump()
    {
        Platforms = GameObject.FindGameObjectsWithTag("plat1");
        Platforms_Script PlatformsScript0 = Platforms[0].GetComponent<Platforms_Script>();
        Platforms_Script PlatformsScript1 = Platforms[1].GetComponent<Platforms_Script>();
        Platforms_Script PlatformsScript2 = Platforms[2].GetComponent<Platforms_Script>();
        var bxCol0 = Platforms[0].GetComponent<BoxCollider2D>();
        var bxCol1 = Platforms[1].GetComponent<BoxCollider2D>();
        var bxCol2 = Platforms[2].GetComponent<BoxCollider2D>();

        if (PlatformsScript0.readyForJump && jump == 0)
        {
            jump = 1;
            bxCol2.isTrigger = true;
            bxCol1.isTrigger = true;
            bxCol0.isTrigger = false;
        }
        else if (PlatformsScript1.readyForJump && jump == 1)
        {
            jump = 2;
            bxCol2.isTrigger = true;
            bxCol1.isTrigger = false;
            bxCol0.isTrigger = true;
        }
        else if (PlatformsScript2.readyForJump && jump == 2)
        {
            jump = 3;
            bxCol2.isTrigger = false;
            bxCol1.isTrigger = true;
            bxCol0.isTrigger = true;
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            onAnim = true;
            armatureComponent.animation.FadeIn("Jump1", -1, 1);
            armatureComponent.animation.GotoAndStopByFrame("Jump1", 3);
            rb.AddForce(new Vector2(0, jumpStr), ForceMode2D.Impulse);

        }
        if (rb.velocity.y < 0.0f && !isGetting)
        {
            //print("entre");
            armatureComponent.animation.GotoAndPlayByFrame("Falling1", 4, 1);
        }

    }
    private void CharacterFall()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !onFloor)
        {
           
            for (int i = 0; i < Platforms.Length; i++)
            {
                if (Platforms[i].GetComponent<Platforms_Script>().playerOnColl)
                {
                    Platforms[i].GetComponent<Collider2D>().enabled = false;
                    if(i!=0)
                    {
                        Platforms[i - 1].GetComponent<Collider2D>().enabled = true;
                        Platforms[i - 1].GetComponent<Collider2D>().isTrigger = false;
                        jump = i-1;
                    }
                    
                    
                    transform.position -= new Vector3(0, dropForce, 0);
                }

            }
        }
    }
}







//Codigo que no funciono, me dio cosa borrarlo

  //if (Input.GetKeyDown(KeyCode.Space) && PlatformsScript0.readyForJump && jump == 0)
        //{
        //    jump = 1;
        //    //float plat0PosY = Platforms[0].transform.position.y;
        //    //armatureComponent.animation.FadeIn("Jump1", -1, 1);
        //    //transform.position = new Vector3(posX, plat0PosY - posY, posZ);
        //    bxCol2.isTrigger = true;
        //    bxCol1.isTrigger = true;
        //    bxCol0.isTrigger = false;
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && PlatformsScript1.readyForJump && jump == 1)
        //{
        //    jump = 2;
        //    //float plat1PosY = Platforms[1].transform.position.y;
        //    //armatureComponent.animation.FadeIn("Jump1", -1, 1);
        //    //transform.position = new Vector3(posX, plat1PosY - posY + 2, posZ);
        //    bxCol2.isTrigger = true;
        //    bxCol1.isTrigger = false;
        //    bxCol0.isTrigger = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && PlatformsScript2.readyForJump && jump == 2)
        //{
        //    jump = 3;
        //    //float plat2PosY = Platforms[2].transform.position.y;
        //    //armatureComponent.animation.FadeIn("Jump1", -1, 1);
        //    //transform.position = new Vector3(posX, plat2PosY + posY - 6.2f, posZ);
        //    bxCol2.isTrigger = false;
        //    bxCol1.isTrigger = true;
        //    bxCol0.isTrigger = true;
        //}
        //if (rb.velocity.y <= 0 && Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if(jump == 3)
        //    {
        //        jump = 2;
        //        bxCol2.isTrigger = true;
        //        bxCol1.isTrigger = false;
        //        bxCol0.isTrigger = true;
        //    }
        //    else if(jump == 2)
        //    {
        //        jump = 1;
        //        bxCol2.isTrigger = false;
        //        bxCol1.isTrigger = false;
        //        bxCol0.isTrigger = true;
        //    }
        //    else if(jump == 1)
        //    {
        //        bxCol2.isTrigger = true;
        //        bxCol1.isTrigger = true;
        //        bxCol0.isTrigger = false;
        //    }
        //}