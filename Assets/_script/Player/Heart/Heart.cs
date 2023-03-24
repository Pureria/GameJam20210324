using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Animator Anim;
    private string nowTrueAnimation;

    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        Anim = GetComponent<Animator>();
        Anim.SetBool("none", true);
        nowTrueAnimation = "none";
    }

    private void Update()
    {

        if (player.CollisionSenses.cliticalRange)
        {
            Anim.SetBool(nowTrueAnimation, false);
            nowTrueAnimation = "critical";
            Anim.SetBool(nowTrueAnimation,true);
        }
        else if (player.CollisionSenses.minRange)
        {
            Anim.SetBool(nowTrueAnimation, false);
            nowTrueAnimation = "min";
            Anim.SetBool(nowTrueAnimation, true);
        }
        else if (player.CollisionSenses.middleRange)
        {
            Anim.SetBool(nowTrueAnimation, false);
            nowTrueAnimation = "middle";
            Anim.SetBool(nowTrueAnimation, true);
        }
        else if (player.CollisionSenses.maxRange)
        {
            Anim.SetBool(nowTrueAnimation, false);
            nowTrueAnimation = "max";
            Anim.SetBool(nowTrueAnimation, true);
        }
    }
}
