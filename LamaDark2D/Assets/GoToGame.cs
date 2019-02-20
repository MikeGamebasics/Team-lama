﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ChangesScene("GamePlay");
        }

        void ChangesScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}