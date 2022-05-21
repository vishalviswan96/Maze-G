using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GScript : MonoBehaviour
{
    Animator anim;
    private Vector3 destination = new Vector3(17, 43, 0);
    private bool playStuff;

    public GameObject mainPanel;
    public GameObject caselevel;
    
    private void Start()
    {
        playStuff = false;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PacMan")
        {
            mainPanel.SetActive(true);
            caselevel.SetActive(true);
            Manager.instance.IncrementG();
            PacMan.instance.PackmanInitial();
            //gameObject.SetActive(gameObject);
            //Destroy(gameObject, 2f);
            //Manager.instance.MainPanel1Active();
            Debug.Log("hit");
            /*anim.Play("G");
            playStuff = true;
            Manager.instance.isTimerRunning = false;
            AudioManager.instance.Correct();
            collision.gameObject.GetComponent<PacMan>().Invincible();*/
        }
    }

    private void Update()
    {
        if (playStuff == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, 7 * Time.deltaTime);
            if (Vector3.Distance(transform.position, destination) < 0.05f)
            {
                playStuff = false;
                //Manager.instance.CollectG();
                Destroy(gameObject);
            }
        }
    }
}
