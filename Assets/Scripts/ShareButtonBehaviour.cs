﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Models;
using Proyecto26;
using UnityEngine.Networking;

public class ShareButtonBehaviour : MonoBehaviour
{
    private readonly string basePath = "theyearthatwas.in";
    private RequestHelper currentRequest;
    private string Score_ID;

    [DllImport("__Internal")]
    private static extern void openWindow(string url);

    [DllImport("__Internal")]
    private static extern void printToConsole(string log);

    [DllImport("__Internal")]
    private static extern string fetchUrl(string url);

    [DllImport("__Internal")]
    private static extern string GetSessionData(string score);

//    public InputField Field;
    //Text TextBox;
    PlayerBehaviour playerScript;
    string score;
    void Start()
    {
        playerScript = GetComponent<PlayerBehaviour>();
    }


    public void SendData(string scorestring)
    {
        score = scorestring;
        StartCoroutine(SendMethod());
        
    }

    public IEnumerator SendMethod()
    {
        //if (Application.isEditor)
        //{
        //    print("We are running this from inside of the editor!");
        //}
        //else
        {
            printToConsole("Score:" + score);
            string FSessionData = GetSessionData(score);
            printToConsole("SessionData:" + FSessionData);
            Get(FSessionData);
            yield return new WaitForSeconds(2);
            printToConsole("PreScoreId:" + Score_ID);
            
        }
        
    }

    public void Get(string FSessionData)
    {
        RestClient.Get<Score>("https://" + basePath + FSessionData).Then(response => {
            Score_ID = response.score_id;
        });

    }

    public void LaunchShareWindow()
    {
        printToConsole("ScoreId:" + Score_ID);
        openWindow("https://www.facebook.com/sharer/sharer.php?u=" + basePath + "/score_id/" + Score_ID + "?url=" + basePath + "&image_src=" + basePath + "/images/" + Score_ID + ".png&hashtag=%23YearEnder2020Game");
    }
}
