using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroScene : MonoBehaviour
{
    public void Scene1(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SetPacMan()
    {
        PacMan.instance.StartDelay();
    }
}
