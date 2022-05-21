using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRight : MonoBehaviour
{
    private void Start()
    {
    }
    public void Right()
    {
        PacMan.instance.RightArrow();
    }
}
