using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{

    public Nodes[] neighbours;
    public Vector2[] validDirections;

    private void Start()
    {
        validDirections = new Vector2[neighbours.Length];
        for(int i = 0; i < neighbours.Length; i++)
        {
            Nodes neighbour = neighbours[i];
            Vector2 tempVector = neighbour.transform.localPosition - transform.localPosition;
            validDirections[i] = tempVector.normalized;
        }

    }
}
