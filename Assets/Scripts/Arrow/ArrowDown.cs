using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDown : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Down()
    {
        PacMan.instance.DownArrow();
    }
}
