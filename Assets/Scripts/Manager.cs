using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static Manager instance;

    public GameObject[] collect;
    public int gCount;
    public int gcountAmount;

    public int score;
    public Text scoreText;

    public GameObject resultPanel;
    public Text percentageMarks;
    public int compareMark;
    public string res;
    public int finalPercent;
    private void Start()
    {
        instance = this;
    }

    public void IncrementG()
    {
        gCount++;

        if (gCount < gcountAmount)
        {
            collect[gCount - 1].SetActive(false);
            collect[gCount].SetActive(true);
        }
        else
        {
            collect[gCount - 1].SetActive(false);
            Debug.Log("GameOver");
        }
        
    }


    public void IncrementScore(int data)
    {
        score += data;
        scoreText.text = score.ToString();
    }

    public void ShowResuts()
    {
        /*finalPercent = (score / compareMark) * 100;
        res = finalPercent.ToString();*/
        percentageMarks.text = "Congratulations! You have unlocked " + Random.Range(80, 100) + "% confident decisions for your patients with the comprehensive genetic investigation solutions from Lilac Insights";
        resultPanel.SetActive(true);
    }

}









