using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public void Reload()
    {
        Destroy(Manager.instance.gameObject);
        Destroy(PacMan.instance.gameObject);
        SceneManager.LoadScene(0);
    }

}
