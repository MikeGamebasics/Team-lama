using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEscToExit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangesScene("StartGame");
        }

        void ChangesScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
