using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    Animator titleAnimator;
    Swatter swatter;
 
    void Start()
    {
        titleAnimator = GetComponent<Animator>();
        swatter = FindObjectOfType<Swatter>();
    }
    //Animates Title
    public void WobbleTitle()
    {
        titleAnimator.SetTrigger("Wobble");
    }
}
