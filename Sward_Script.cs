using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sward_Script : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollision = true;
        var PjScript = Pj.GetComponent<Pj_Script>();
        if (gameObject.tag == "SwordQ")
        {
            PjScript.swordPrepareQ = true;
        }
        if (gameObject.tag == "SwordE")
        {
            PjScript.swordPrepareE = true;
        }

        ChangeSprite();
        
        
    }
    public float speed;
    public bool canTp = false;
    public bool onCollision = false;
    public Vector3 position;
    private GameObject Pj;
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = sprite1;
        }
             
        Pj = GameObject.FindGameObjectWithTag("Player");
        
    }
    void ChangeSprite()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!onCollision)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            position = transform.position;
            
            
        }
        else
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

            speed = 0;
            canTp = true;
        }

        
    }
}
