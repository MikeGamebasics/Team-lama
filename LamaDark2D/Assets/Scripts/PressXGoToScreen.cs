using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressXGoToScreen : MonoBehaviour
{
    bool animateTextIsDone = false;
    bool animationStarted = false;

    GameObject animateText;

    // Start is called before the first frame update
    void Start()
    {
        animateText = GameObject.Find("flavorText");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !animateTextIsDone)
        {
            animationStarted = true;
            var gameTitleObject = GameObject.Find("gameTitle");
            var pressToCont = GameObject.Find("PressToContinue");

            Destroy(gameTitleObject);
            Destroy(pressToCont);

            animateText.GetComponent<Animation>().Play();

        }

        if (!animateText.GetComponent<Animation>().isPlaying && animationStarted && !animateTextIsDone)
        {
            animateTextIsDone = true;
        }

        if (animateTextIsDone && Input.GetKeyDown("space"))
        {
            ChangesScene("GamePlay");
        }

        void ChangesScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
