using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTextHunter : MonoBehaviour
{
    public float showTextDuration;
    public float intervalBetweenTexts;
    float intervalSinceLastUpdate;
    public static string randomHunterText;

    //insert random text here
    string[] randomHunterTexts = { "What are you doing?", "Git Gud", "you weakling", "You can't defeat me!", "Is this all?", "Nani, the Fuck?" };

    // Start is called before the first frame update
    void Start()
    {
        AppointRandomText();
    }

    // Update is called once per frame
    void Update()
    {
        intervalSinceLastUpdate += Time.deltaTime;
        if (intervalSinceLastUpdate >= intervalBetweenTexts)
        {
            intervalSinceLastUpdate -= intervalBetweenTexts;
            Invoke("AppointRandomText", showTextDuration);
            GetComponent<TextMesh>().text = null;
        }

    }

    void AppointRandomText()
    {
        //gets a random index number
        int randomIndex = Mathf.FloorToInt(Random.Range(0, randomHunterTexts.Length));
        randomHunterText = randomHunterTexts[randomIndex];

        //shows text above player. N is needed so it is indeed above the player
        GetComponent<TextMesh>().text = randomHunterText + "\n\n\n\n\n";
    }


}