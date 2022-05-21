using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planel : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OkButtonPress()
    {
        anim.Play("Ok");
        WavepointEnemy.startGame = true;
        PacMan.instance.canControl = true;
    }
}
