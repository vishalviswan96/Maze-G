using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard : MonoBehaviour
{
    private static int boardWidth = 100;
    private static int boardHeight = 100;
    public GameObject[,] board = new GameObject[boardWidth, boardHeight];
    // Start is called before the first frame update
    void Start()
    {
        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach(GameObject o in objects)
        {
            Vector2 pos = o.transform.position;
            if (o.name != "PacMan" && o.name != "Canvas" && o.name != "Image" && o.name != "ParentalOption" && o.name != "Case" && o.name != "Intro"
                && o.name != "Button" && o.name != "Panel" && o.name != "Text" && o.name != "TextObj" && o.name != "McqHolder" && o.name != "InputField" && o.name != "Placeholder"
                && o.name != "ButtonObj" && o.name != "Logo" && o.name != "MainCamera" && o.name != "G" && o.name != "EventSystem" && o.name != "NodeObject")
            {
                board[(int)pos.x, (int)pos.y] = o;

            }
            else
            {
                //Debug.Log("Found Player " + pos);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
