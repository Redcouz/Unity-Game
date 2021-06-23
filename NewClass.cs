using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;


public class NewClass : MonoBehaviour
{
    private AnimationController animationController;
    public Rigidbody2D rb;
    void Start()
    {

        animationController = new AnimationController();
        UnityArmatureComponent PjArmature = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityArmatureComponent>();
        Rigidbody2D rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        PjArmature.animation.FadeIn("Idle1", -1, -1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animationController.SetAnimation("walk");
            if (animationController.Flip())
            {
                animationController.Flip();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animationController.SetAnimation("jump");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animationController.SetAnimation("walk");
            if (!animationController.Flip())
            {
                animationController.Flip();
            }
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animationController.SetAnimation("idle");
        }
    }
}
