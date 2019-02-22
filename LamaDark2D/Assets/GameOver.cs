using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    bool GameHasEnded = false;
    public Player playerOne;
    public Player playerTwo;
    //Text winnerTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        if (playerOne.Health == 0 || playerTwo.Health == 0)
        {

            GameHasEnded = true;
        }

        if (GameHasEnded)
        {
            ChangesScene("EndGame");
        }

        void ChangesScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
