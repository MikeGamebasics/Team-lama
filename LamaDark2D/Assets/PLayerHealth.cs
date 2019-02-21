using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerHealth : MonoBehaviour
{
    Text playerHP;
    int CountDown = 100;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = GetComponent<Text>();
        playerHP.text = CountDown.ToString() + "%";
        CountDown--;

    }
}
