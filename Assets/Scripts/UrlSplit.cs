using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UrlSplit : MonoBehaviour
{
    public static UrlSplit instance;

    public InputField ipName;
    public InputField ipEmail;
    public InputField ipMobile;
    public InputField ipCity;
    public InputField ipClinic;
    public string speciality;

    public GameObject formFailPanel;

    public string name, email, mobile, city, clinic;
    public string savedata;
    //public string savedata = "http://www.apexfaaydaquiz.com/BBM3/maze.php";
    private bool isSelfiButtonPressed;
    //"http://www.apexfaaydaquiz.com/BBM3/maze.php?name=Singh&email=singhaashu786@gmail.com&mobile=8797670199&%20speciality=xyz"

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isSelfiButtonPressed = false;
        
    }

   
    public void CallSaveData()
    {
        name = ipName.text;
        email = ipEmail.text;
        mobile = ipMobile.text;
        city = ipCity.text;
        clinic = ipClinic.text;
        savedata = "http://www.apexfaaydaquiz.com/BBM3/maze.php?" + "name=" + name + "&email=" + email + "&mobile=" + mobile + "&peciality=" + speciality + "&city=" + city + "&clinicname=" + clinic;
        StartCoroutine(SaveData());
       
    }

    IEnumerator SaveData()
    {
        List<IMultipartFormSection> wwwform = new List<IMultipartFormSection>();
        /*wwwform.Add(new MultipartFormDataSection("name", name));
        wwwform.Add(new MultipartFormDataSection("email", email));
        wwwform.Add(new MultipartFormDataSection("mobile", mobile));
        wwwform.Add(new MultipartFormDataSection("speciality", speciality));
        wwwform.Add(new MultipartFormDataSection("city", city));
        wwwform.Add(new MultipartFormDataSection("clinicname", clinic));*/

        UnityWebRequest www = UnityWebRequest.Post(savedata, wwwform);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Network Error : " + www.error);
            formFailPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Return Server Text: " + www.downloadHandler.text);
            string str = www.downloadHandler.text;
            if (str == "1")
            {
                Debug.Log("Data Uploaded");
                PacMan.instance.PackmanRestart();
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.LogError("Data Stoaring Error : " + www.error);
                Debug.Log("Data Upload failed");
                formFailPanel.SetActive(true);

            }
        }

    }

    public void SaveDataOnce()
    {
        
        if (!isSelfiButtonPressed)
        {
            Debug.Log("saveOnce");
            isSelfiButtonPressed = true;
            CallSaveData();
        }

    }

    public void Scene1()
    {
        SceneManager.LoadScene(0);
    }

}


