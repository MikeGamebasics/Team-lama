using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class PullController : MonoBehaviour
{

    public Player player1;
    public Player player2;
    public float push;
    public float pull;

    public KeyCode keypush;
    public KeyCode keypull;

    private float Pushtimer;

    private float Pulltimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pushtimer += Time.deltaTime;
        Pulltimer += Time.deltaTime;

        if (Input.GetKeyDown(keypush))
        {
            if (Pushtimer >= 1f)
            {
                Push(player1.Cube, player2.Cube, 0.2f, 10f, push);
                Pushtimer = 0f;
            }
         
        }

        if (Input.GetKeyDown(keypull))
        {
            if (Pulltimer >= 1f)
            {
                Pull(player1.Cube, player2.Cube, 0.2f, 10f, pull);
                Pulltimer = 0f;
            }
        }

    }

    void Push(GameObject player, GameObject target, float distanceToStop, float distanceMax, float speed)
    {
        
        if (Vector3.Distance(player.transform.position, target.transform.position) > distanceToStop && Vector3.Distance(player1.Cube.transform.position, target.transform.position) < distanceMax)
        {
            Debug.Log("Push");
            target.transform.position = Vector3.MoveTowards(player.transform.position * -1, target.transform.position * -1, speed * Time.deltaTime);target.transform.position = Vector3.MoveTowards(target.transform.position, player.transform.position, speed * Time.deltaTime);
            //Vector2 direction = target.transform.position - player.transform.position;
            //target.transform.Translate(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0);
        }
    }

    void Pull(GameObject player, GameObject target, float distanceToStop, float distanceMax, float speed)
    {

        if (Vector2.Distance(player.transform.position, target.transform.position) > distanceToStop && Vector2.Distance(player1.Cube.transform.position, target.transform.position) < distanceMax)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
