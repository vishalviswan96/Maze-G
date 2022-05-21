using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentalMcq : MonoBehaviour
{
    public GameObject parentalOptinObjetc;
    public GameObject buttonObject;
    public GameObject openPanel;
    public GameObject[] textObj;
    public GameObject textBackButton;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ButtonPress(int code)
    {
        buttonObject.SetActive(false);
        textBackButton.SetActive(true);
        textObj[code].SetActive(true);
        //TextObjectReplace(0);
    }

    void TextObjectReplace()
    {
        foreach(GameObject text in textObj)
        {
            text.SetActive(false);
        }
        //textObj[num].SetActive(true);
    }

    public void OnTextBackPress()
    {
        textBackButton.SetActive(false);
        TextObjectReplace();
        buttonObject.SetActive(true);
    }

    public void NoActionPress()
    {
        openPanel.SetActive(false);
        parentalOptinObjetc.SetActive(false);
    }
    public void BackButtonPress()
    {
        openPanel.SetActive(false);
        parentalOptinObjetc.SetActive(false);
    }

}
