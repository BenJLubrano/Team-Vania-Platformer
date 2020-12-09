﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScenes : MonoBehaviour
{
    public static ChangeScenes instance = null;
    public string nextScene = "Forest";


    public Image black;
    public Animator anim;

    private void Awake()
    {
        //Start at Intro Scene
        instance = this;
        if(SceneManager.GetActiveScene().name == "Team Intro Scene")
        {
            Invoke("loadStart", 5f);
        }
    }
   
   //Scene Changer
   public void ChangeScene(string sceneName)
    {
        StartCoroutine(Fading());
        SceneManager.LoadScene(sceneName);
    }
    //Load Start - Might be used later
    void loadStart()
    {
        ChangeScene(nextScene);
    }
    //Exit Game
    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
    }
}
