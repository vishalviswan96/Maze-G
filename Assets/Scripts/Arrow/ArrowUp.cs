using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowUp : MonoBehaviour
{
    private void Start()
    {
        
    }

    public void Up()
    {
        PacMan.instance.UpArrow();
    }
}
