using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLeft : MonoBehaviour
{
    private void Start()
    {
        
    }
    public void Left()
    {
        PacMan.instance.LeftArrow();
    }
}
