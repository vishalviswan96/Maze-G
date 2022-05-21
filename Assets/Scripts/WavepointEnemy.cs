using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavepointEnemy : MonoBehaviour
{
    public static bool startGame;
    public Transform[] nodes;
    private float speed;
    public int currentNode;
    public Transform myTransform;
    private Vector2 direction;
    private SpriteRenderer sr;
    private float autoStartTimer;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        speed = Random.Range(3f, 5f);
        autoStartTimer = Random.Range(2f, 4f);
        startGame = true;
    }


    private void Update()
    {
        if(startGame == true)
        {
            if (autoStartTimer > 0)
            {
                autoStartTimer -= Time.deltaTime;
            }
            if (autoStartTimer <= 0)
            {
                autoStartTimer = 0;
                myTransform.position = Vector3.MoveTowards(myTransform.position, nodes[currentNode].position, speed * Time.deltaTime);
                if (Vector3.Distance(myTransform.position, nodes[currentNode].position) < 0.05f)
                {
                    currentNode++;

                    if (currentNode >= nodes.Length)
                    {
                        currentNode = 0;
                    }

                    if (currentNode != 0)
                    {
                        Orientation(currentNode, currentNode - 1);
                    }


                }
            }

        }



    }

    void Orientation(int currentIndex, int nextIndex)
    {
        Vector2 tempDir = nodes[currentIndex].localPosition - nodes[nextIndex].localPosition;
        direction = tempDir.normalized;

        if (direction == Vector2.up)
        {
            sr.flipY = true;
            myTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.down)
        {
            sr.flipY = false;
            myTransform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.left)
        {
            sr.flipY = false;
            myTransform.localRotation = Quaternion.Euler(0, 0, 270);
        }
        else if (direction == Vector2.right)
        {
            sr.flipY = false;
            myTransform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }
    

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PacMan")
        {
            collision.gameObject.GetComponent<PacMan>().EnemyAttack();
        }
    }*/
}
