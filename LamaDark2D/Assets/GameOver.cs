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
        anim = playerOne.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        if (playerOne.Health == 0) 
        {
            vampireIsDead = true;
            anim.SetBool("isVampireDead", true);
        }

        if (playerTwo.Health == 0)
        {
            hunterIsDead = true;
            anim.SetBool("isHunterDead", true);
        }


        if(vampireIsDead || hunterIsDead)
        {
            winnerTxt = GameObject.Find("Winner Text");
            winnerTxt.GetComponent<RectTransform>().position = new Vector2(900, 500);
            Text changeWinnerTxt = winnerTxt.GetComponent<Text>();
            if (vampireIsDead)
                { 
                changeWinnerTxt.text = "The winner is: VAMPIRE! \n\nPress SPACE to continue" ; 
                }
            else changeWinnerTxt.text = "The winner is: HUNTER! \n\nPress SPACE to continue" ;

            winnerTxtIsShown = true;
        }

        if (winnerTxtIsShown && Input.GetKeyDown("space"))
        { 
            GameHasEnded = true;
        }

        if (GameHasEnded)
        {
            ChangesScene("EndGame");
            //anim.SetBool("isVampireDead", false);
            //anim.SetBool("isVampireDead", false);
        }

        void ChangesScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
