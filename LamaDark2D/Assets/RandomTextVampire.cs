using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTextVampire : MonoBehaviour
{
    public float showTextDuration;
    public float intervalBetweenTexts;
    float intervalSinceLastUpdate;
    public static string randomVampireText;

    //insert random text here
    string[] randomVampireTexts = { "You suck more than me", "Git Gud", "you weakling", "You can't defeat me!", "Is this all?", "Nani, the Fuck?",
    "Get over here", "Die!!!", "Are you bleeding?", "Stay away from the light", "Come to the darkness", "I will bite you" };

    // Start is called before the first frame update
    void Start()
    {
        AppointRandomText();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion newRotation = GetComponent<TextMesh>().transform.rotation;
        newRotation.y = 0;
        GetComponent<TextMesh>().transform.rotation = newRotation;

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
        int randomIndex = Mathf.FloorToInt(Random.Range(0, randomVampireTexts.Length));
        randomVampireText = randomVampireTexts[randomIndex];

        //shows text above player. N is needed so it is indeed above the player
        GetComponent<TextMesh>().text = randomVampireText + "\n\n\n\n\n";
    }


}