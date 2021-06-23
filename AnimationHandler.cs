using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class AnimationHandler 
{
    UnityArmatureComponent armatureComponent;
    Dictionary<string, AnimationHandler> dictionary;
   
    string name;
    
    public AnimationHandler(string name, UnityArmatureComponent armatureComponent)//pasale el armature
    {
        this.armatureComponent = armatureComponent;
        this.name = name;
    }
    public void Init(Dictionary<string,AnimationHandler> dictionary)
    {
        this.dictionary = dictionary;
    }
    public AnimationHandler SetAnimation(string name)
    {
        if (dictionary.ContainsKey(name))
        {
            //acá llamá el armature con este parámetro: 
            //dictionary[name].GetName();

            armatureComponent.animation.FadeIn(dictionary[name].GetName(), -1, -1); 
            return dictionary[name];
        }
        return null;
    }
    public string GetName()
    {
        return name;
    }
}
