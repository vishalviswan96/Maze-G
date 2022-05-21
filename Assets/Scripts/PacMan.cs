using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PacMan : MonoBehaviour
{
    public static PacMan instance;
    public float speed = 6f;
    private SpriteRenderer sr;
    private BoxCollider2D rb;
    private Vector2 direction = Vector2.zero;
    private Vector2 nextDirection;
    public Nodes currentNode, previousNode, targetNode;
    public Nodes initialNode;
    public bool canControl;
    private AudioSource audio;
    public Button up, down, left, right;
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
        }
        audio = GetComponent<AudioSource>();
        Initialize();
        canControl = true;

        up.onClick.AddListener(UpArrow);
        down.onClick.AddListener(DownArrow);
        left.onClick.AddListener(LeftArrow);
        right.onClick.AddListener(RightArrow);
    }

    public void StartDelay()
    {
        StartCoroutine(DelayInit());
    }
    IEnumerator DelayInit()
    {
        
        yield return new WaitForSeconds(1f);
        Test();
    }

    public void Test()
    {
        Debug.Log("delay");
        GameObject obj = GameObject.FindGameObjectWithTag("Node");
        initialNode = obj.GetComponent<Nodes>();
        Initialize();


        
        /*rb.enabled = true;
        if (index == 1)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Node");
            initialNode = obj.GetComponent<Nodes>();
            Initialize();
        }
        if (index == 2)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Node");
            initialNode = obj.GetComponent<Nodes>();
            Initialize();
        }
        if (index == 3)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Node");
            initialNode = obj.GetComponent<Nodes>();
            Initialize();
        }
        if (index == 4)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Node");
            initialNode = obj.GetComponent<Nodes>();
            Initialize();
        }
        if (index == 5)
        {
            sr.enabled = false;
            canControl = false;
        }*/
    }
    void Initialize()
    {
        canControl = true;
        rb = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        transform.position = initialNode.transform.position;
        Nodes node = GetNodeAtPosition(transform.position);
        if (node != null)
        {
            currentNode = node;
            Debug.Log(currentNode);
        }
        //PackmanInitial();

        initialNode = currentNode;
    }

    void Update()
    {
        if (canControl == true)
        {
            CheckInput();
            Move();
            UpdateOrientation();
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            PackmanRestart();
        }
    }
    public void UpArrow()
    {
        if (canControl == true)
        {
            ChangePosition(Vector2.up);

        }
    }

    public void DownArrow()
    {
        if (canControl == true)
            ChangePosition(Vector2.down);
    }

    public void LeftArrow()
    {
        if (canControl == true)
            ChangePosition(Vector2.left);

    }
    public void RightArrow()
    {
        if (canControl == true)
            ChangePosition(Vector2.right);
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            /*direction = Vector2.up;
            MoveToNode(direction);*/
            ChangePosition(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            /*direction = Vector2.down;
            MoveToNode(direction);*/
            ChangePosition(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            /*direction = Vector2.left;
            MoveToNode(direction);*/
            ChangePosition(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            /*direction = Vector2.right;
            MoveToNode(direction);*/
            ChangePosition(Vector2.right);
        }

    }

    void ChangePosition(Vector2 d)
    {
        AudioManager.instance.ButtonFx();
        Debug.Log("Input");
        if (d != direction)
        {
            nextDirection = d;
        }
        if (currentNode != null)
        {
            Nodes moveTONode = CanMove(d);
            if (moveTONode != null)
            {
                //audio.Play();
                direction = d;
                targetNode = moveTONode;
                previousNode = currentNode;
                currentNode = null;
            }
        }

    }
    /*void MoveToNode(Vector2 d)
    {
        Nodes moveToNode = CanMove(d);
        if (moveToNode != null)
        {
            transform.localPosition = moveToNode.transform.localPosition;
            currentNode = moveToNode;
        }
    }*/

    void Move()
    {
        if (targetNode != currentNode && targetNode != null)
        {
            if (nextDirection == direction * -1)
            {
                direction *= -1;
                Nodes tempNode = targetNode;
                targetNode = previousNode;
                previousNode = tempNode;
            }
            if (OverShotTarget())
            {
                currentNode = targetNode;
                transform.localPosition = currentNode.transform.position;

                GameObject otherPortal = GetPortal(currentNode.transform.position);
                if (otherPortal != null)
                {
                    transform.localPosition = otherPortal.transform.position;
                    currentNode = otherPortal.GetComponent<Nodes>();
                }
                Nodes moveToNode = CanMove(nextDirection);
                if (moveToNode != null)
                {
                    direction = nextDirection;
                }
                if (moveToNode == null)
                {
                    moveToNode = CanMove(direction);
                }
                if (moveToNode != null)
                {
                    targetNode = moveToNode;
                    previousNode = currentNode;
                    currentNode = null;
                }
                else
                {
                    direction = Vector2.zero;
                    //audio.Stop();
                }
            }
            else
            {
                transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;

            }
        }

    }

    void UpdateOrientation()
    {

        if (direction == Vector2.left)
        {
            sr.flipX = true;
        }
        else if (direction == Vector2.right)
        {
            sr.flipX = false;
        }
    }

    Nodes CanMove(Vector2 d)
    {
        Nodes moveToNode = null;
        for (int i = 0; i < currentNode.neighbours.Length; i++)
        {
            if (currentNode.validDirections[i] == d)
            {
                moveToNode = currentNode.neighbours[i];
                break;
            }
        }
        return moveToNode;
    }

    Nodes GetNodeAtPosition(Vector2 pos)
    {
        GameObject tile = GameObject.Find("Gameboard").GetComponent<Gameboard>().board[(int)pos.x, (int)pos.y];
        if (tile != null)
        {
            return tile.GetComponent<Nodes>();
        }
        return null;
    }
    bool OverShotTarget()
    {
        float nodeToTarget = LengthFromNode(targetNode.transform.position);
        float nodeTosSelf = LengthFromNode(transform.localPosition);
        return nodeTosSelf > nodeToTarget;
    }
    float LengthFromNode(Vector2 targetPosition)
    {
        Vector2 vec = targetPosition - (Vector2)previousNode.transform.position;
        return vec.sqrMagnitude;
    }
    GameObject GetPortal(Vector2 pos)
    {
        GameObject tile = GameObject.Find("Gameboard").GetComponent<Gameboard>().board[(int)pos.x, (int)pos.y];
        if (tile != null)
        {
            if (tile.GetComponent<Tile>() != null)
            {
                if (tile.GetComponent<Tile>().isPortal)
                {
                    GameObject otherPortal = tile.GetComponent<Tile>().portalReciever;
                    return otherPortal;
                }
            }
        }
        return null;
    }

    public void PackmanInitial()
    {
        Debug.Log("PackInit");
        //targetNode = null;
        currentNode = targetNode;
        previousNode = targetNode;
        //transform.position = initialNode.transform.position;
        /*Nodes node = GetNodeAtPosition(initialNode.transform.position);
        if (node != null)
        {
            currentNode = node;
            Debug.Log(currentNode);
        }*/
    }

    public void PackmanRestart()
    {
        Debug.Log("PackInit");
        targetNode = null;
        previousNode = null;
        currentNode = null;
        transform.position = initialNode.transform.position;
        Nodes node = GetNodeAtPosition(initialNode.transform.position);
        if (node != null)
        {
            currentNode = node;
            Debug.Log(currentNode);
        }
        SceneManager.LoadScene(0);
    }
}

    /*public void EnemyAttack()
    {
        //audio.Stop();
        Manager.instance.GotHit();
        if (Manager.instance.heartCount <= 3)
        {
            canControl = false;
            sr.enabled = false;
            direction = Vector2.zero;
            nextDirection = Vector2.zero;
            PackmanInitial();

            //transform.localPosition = initialNode.transform.localPosition;
            StartCoroutine(Revive());
        }
        else
        {
            canControl = false;
            sr.enabled = false;
        }


    }*/

    /*void PackmanInitial()
    {
        Debug.Log("PackInit");
        targetNode = null;
        previousNode = null;
        currentNode = null;
        transform.position = initialNode.transform.position;
        Nodes node = GetNodeAtPosition(initialNode.transform.position);
        if (node != null)
        {
            currentNode = node;
            Debug.Log(currentNode);
        }
    }
    IEnumerator Revive()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);
        yield return new WaitForSeconds(0.5f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.5f);
        canControl = true;
        sr.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sr.enabled = true;
        yield return new WaitForSeconds(0.5f);
        sr.enabled = false;
        yield return new WaitForSeconds(0.5f);
        sr.enabled = true;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
    }

    public void Invincible()
    {
        rb.enabled = false;
    }*/
