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
    private Animator anim1;
    private Animator anim2;
    private bool vampireIsDead = false;
    private bool hunterIsDead = false;
    private int winnerTxtIsShown = 0;
    private GameObject winnerTxt;


    // Start is called before the first frame update
    void Start()
    {
        anim1 = playerOne.GetComponent<Animator>();
        anim2 = playerTwo.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()

    {
        if (playerOne.Health == 0 && !vampireIsDead) 
        {
            hunterIsDead = true;
            anim1.SetBool("isHunterDead", true);
        }

        if (playerTwo.Health == 0 && !hunterIsDead)
        {
            vampireIsDead = true;
            anim2.SetBool("isVampireDead", true);

        }


        if((vampireIsDead || hunterIsDead )&& winnerTxtIsShown == 0)
        {
            winnerTxt = GameObject.Find("Winner Text");
            winnerTxt.GetComponent<RectTransform>().position = new Vector2(900, 500);
            Text changeWinnerTxt = winnerTxt.GetComponent<Text>();
            if (hunterIsDead)
                { 
                changeWinnerTxt.text = "The winner is: VAMPIRE! \n\nPress SPACE to continue" ; 
                }
            else changeWinnerTxt.text = "The winner is: HUNTER! \n\nPress SPACE to continue" ;

            winnerTxtIsShown = 1;
        }

        if (winnerTxtIsShown > 0 && Input.GetKeyDown("space"))
        { 
            GameHasEnded = true;
        }

        if (GameHasEnded)
        {
            ChangesScene("EndGame");
            anim1.SetBool("isVampireDead", false);
            anim2.SetBool("isHunterDead", false);
        }

        void ChangesScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
