using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class AnimationController 
{
    UnityArmatureComponent armatureComponent = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityArmatureComponent>(); 
    AnimationHandler currentAnimation;
    // Start is called before the first frame update
    public AnimationController()
    {
        AnimationHandler Idle1 = new AnimationHandler("Idle1", armatureComponent);
        AnimationHandler Idle2 = new AnimationHandler("Idle2", armatureComponent);
        AnimationHandler Idle3 = new AnimationHandler("Idle3", armatureComponent);
        AnimationHandler Walk1 = new AnimationHandler("Walk1", armatureComponent);
        AnimationHandler Walk2 = new AnimationHandler("Walk2", armatureComponent);
        AnimationHandler Walk3 = new AnimationHandler("Walk3", armatureComponent);
        AnimationHandler Attack1 = new AnimationHandler("Attack1", armatureComponent);
        AnimationHandler Attack2 = new AnimationHandler("Attack2", armatureComponent);
        AnimationHandler Jump1 = new AnimationHandler("Jump1", armatureComponent);
        AnimationHandler Jump2 = new AnimationHandler("Jump2", armatureComponent);
        AnimationHandler Jump3 = new AnimationHandler("Jump3", armatureComponent);
        AnimationHandler Falling1 = new AnimationHandler("Falling1", armatureComponent);
        AnimationHandler Falling2 = new AnimationHandler("Falling2", armatureComponent);
        AnimationHandler Falling3 = new AnimationHandler("Falling3", armatureComponent);
        AnimationHandler ThrowSword1Handed = new AnimationHandler("ThrowSword1Handed", armatureComponent);
        AnimationHandler ThrowSword2Handed = new AnimationHandler("ThrowSword2Handed", armatureComponent);
        AnimationHandler Invocation = new AnimationHandler("Invocation", armatureComponent);
        AnimationHandler GetSword1Handed = new AnimationHandler("GetSword1Handed", armatureComponent);
        AnimationHandler GetSword2Handed = new AnimationHandler("GetSword2Handed", armatureComponent);


        Idle1.Init(new Dictionary<string, AnimationHandler>() { { "walk", Walk1 }, { "jump", Jump1 }, { "falling", Falling1 }, {"invocation", Invocation }, { "getsword", GetSword1Handed } });
        Walk1.Init(new Dictionary<string, AnimationHandler>() { { "jump", Jump1 }, { "falling", Falling1 }, { "idle", Idle1 } });
        Jump1.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle1 } });
        Falling1.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle1 }, { "walk", Walk1 } });
        Invocation.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle2 } });
        GetSword1Handed.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle3 } });


        Idle2.Init(new Dictionary<string, AnimationHandler>() { { "walk", Walk2 }, { "jump", Jump2 }, { "falling", Falling2 }, { "attack", Attack1 }, { "throwsword", ThrowSword2Handed } });
        Walk2.Init(new Dictionary<string, AnimationHandler>() { { "jump", Jump2 }, { "falling", Falling2 }, { "idle", Idle2 } });
        Jump2.Init(new Dictionary<string, AnimationHandler>() { { "falling", Falling2 } });
        Falling2.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle2 }, { "walk", Walk2 } });
        Attack1.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle2 } });
        ThrowSword2Handed.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle3 } });


        Idle3.Init(new Dictionary<string, AnimationHandler>() { { "walk", Walk3 }, { "jump", Jump3 }, { "falling", Falling3 }, { "attack", Attack2 }, { "throwsword", ThrowSword1Handed }, { "getsword", GetSword2Handed } });
        Walk3.Init(new Dictionary<string, AnimationHandler>() { { "jump", Jump3 }, { "falling", Falling3 }, { "idle", Idle3 } });
        Jump3.Init(new Dictionary<string, AnimationHandler>() { { "falling", Falling3 } });
        Falling3.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle3 }, { "walk", Walk3 } });
        Attack2.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle3 } });
        ThrowSword1Handed.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle1 } });
        GetSword2Handed.Init(new Dictionary<string, AnimationHandler>() { { "idle", Idle2 } });

        currentAnimation = Idle1;

    }

    public void SetAnimation(string name)
    {
        AnimationHandler aux = currentAnimation.SetAnimation(name);
        if (aux != null)
        {
            currentAnimation = aux;
            Debug.Log(currentAnimation.GetName());
        }
    }
    public bool Flip()
    {
        if (armatureComponent.armature.flipX)
        {
            armatureComponent.armature.flipX = false;
            return false;
        }
        else
        {
            armatureComponent.armature.flipX = true;
            return true;
        }

    }
}
