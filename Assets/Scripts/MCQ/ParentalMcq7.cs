using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentalMcq7 : MonoBehaviour
{
    public GameObject parentalOptinObjetc;
    public GameObject buttonObject;
    public GameObject selectOptionObject;
    public GameObject openPanel;
    public GameObject[] textObj;
    public GameObject textBackButton;

    public bool isButton;
    private void Start()
    {
        isButton = false;
    }

    private void Update()
    {

    }

    public void OnButtonPress(int code)
    {
        selectOptionObject.SetActive(false);
        buttonObject.SetActive(false);
        textBackButton.SetActive(true);

        textObj[code].SetActive(true);

    }


    public void SelectButtonPress()
    {
        selectOptionObject.SetActive(true);
    }

    void TextObjectReplace()
    {
        foreach (GameObject text in textObj)
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
