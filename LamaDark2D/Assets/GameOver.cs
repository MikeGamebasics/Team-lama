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
    private Animator anim;
    private bool vampireIsDead = false;
    private bool hunterIsDead = false;
    private bool winnerTxtIsShown = false;
    private GameObject winnerTxt;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        if (playerOne.Health == 0) 
        {
            //anim.isVampireDead = true;
            vampireIsDead = true;
        }

        if (playerTwo.Health == 0)
        {
            //anim.isHunterDead = true;
            hunterIsDead = true;
        }


        if(vampireIsDead || hunterIsDead)
        {
            winnerTxt = GameObject.Find("Winner Text");
            winnerTxt.GetComponent<RectTransform>().position = new Vector2(900, 500);
            Text changeWinnerTxt = winnerTxt.GetComponent<Text>();
            if (vampireIsDead)
                { 
                changeWinnerTxt.text = "The winner is: VAMPIRE!"; 
                }
            else changeWinnerTxt.text = "The winner is: HUNTER!";

            winnerTxtIsShown = true;
        }

        if (winnerTxtIsShown && Input.GetKeyDown("space"))
        { 
            GameHasEnded = true;
        }

        if (GameHasEnded)
        {
            ChangesScene("EndGame");
            //anim.isVampireDead = false;
            //anim.isHunterDead = false;
        }

        void ChangesScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
