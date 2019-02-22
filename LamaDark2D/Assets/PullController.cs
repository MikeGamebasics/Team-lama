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
                Push(player1.Cube, player2.Cube, 0f, 1.5f, push);
                Pushtimer = 0f;
                FindObjectOfType<AudioManager>().Play("Push");
            }

        }

        if (Input.GetKeyDown(keypull))
        {
            if (Pulltimer >= 1f)
            {
                Pull(player1.Cube, player2.Cube, 2f, 10f, pull);
                Pulltimer = 0f;
                FindObjectOfType<AudioManager>().Play("Pull");
            }
        }

    }

    void Push(GameObject player, GameObject target, float distanceToStop, float distanceMax, float speed)
    {
        
        if (Vector3.Distance(player.transform.position, target.transform.position) > distanceToStop && Vector3.Distance(player1.Cube.transform.position, target.transform.position) < distanceMax)
        {
            var direction = player.transform.position - target.transform.position;

            target.transform.position += direction.normalized * speed * Time.deltaTime * -1 * 5;
            Debug.Log("Push");
            //    target.transform.position = Vector3.MoveTowards(player.transform.position , target.transform.position, speed * Time.deltaTime * -1);
        }
    }

        void Pull(GameObject player, GameObject target, float distanceToStop, float distanceMax, float speed)
    {

        if (Vector2.Distance(player.transform.position, target.transform.position) > distanceToStop && Vector2.Distance(player1.Cube.transform.position, target.transform.position) < distanceMax)
        {
            var direction = player.transform.position - target.transform.position;

            target.transform.position += direction.normalized * speed * Time.deltaTime * 10;
        }
    }
}
