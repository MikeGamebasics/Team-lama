using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSelectController1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            Vector2 position = this.transform.position;
            position.x = (330);
            this.transform.position = position;
        }

        if (Input.GetKeyDown("right"))
        {
            Vector2 position = this.transform.position;
            position.x = (730);
            this.transform.position = position;
        }
    }
}
