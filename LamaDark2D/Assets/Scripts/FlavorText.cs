using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavorText : MonoBehaviour
{
    Animation animateText;

    public void ShowFlavorText(GameObject flavorText)
    {
        //changes text
        Text myText = flavorText.GetComponent<Text>();
        Debug.Log(myText.text);
        myText.text = "The old tales speak of a great battle between the two great races. " +
        	"One who shines in the light and the other who bathes in the darkness. " +
        	"Ones weakness was the others strength and so the battle was one of deception and swiftness. " +
        	"If one could move one towards the dark or push one towards the light, their bodies wouldn’t hold together. " +
        	"They would simply perish if one wasn’t made for it. " +
        	"The race of darkness was often known as ‘Vampires’ whereas the ones who battled such creatures were named ‘Hunters’. " +
        	"Though the tales say the Hunters won, vampires were deceptive creatures. " +
        	"Tales are often told by the victors and in this case.. \n\nWhich truth is more convenient to be told?";
        Debug.Log(myText.text);

        //gets animation and plays it
        animateText = flavorText.GetComponent<Animation>();
        animateText.Play();
    }

    void Update()
    {
        if (!animateText.isPlaying && animateText != null)
        {
            MenuScript.ChangeScene("SampleScene");
        }
    }
}
