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
                Push(player1.Cube, player2.Cube, 0.2f, 2f, push);
                Pushtimer = 0f;
            }
         
        }

        if (Input.GetKeyDown(keypull))
        {
            if (Pulltimer >= 1f)
            {
                Pull(player1.Cube, player2.Cube, 0.2f, 4f, pull);
                Pulltimer = 0f;
            }
        }

    }

    void Push(GameObject player, GameObject target, float distanceToStop, float distanceMax, float speed)
    {

        if (Vector3.Distance(player1.Cube.transform.position, target.transform.position) > distanceToStop && Vector3.Distance(player1.Cube.transform.position, target.transform.position) < distanceMax)
        {
            
            Vector2 direction = target.transform.position - player.transform.position;
            Debug.Log(direction);
            var rigidbody = target.GetComponent<Rigidbody2D>();
            Debug.Log(direction * speed);
            Debug.Log(rigidbody);
            rigidbody.AddForce(direction * speed, ForceMode2D.Impulse);
        }
    }

    void Pull(GameObject player, GameObject target, float distanceToStop, float distanceMax, float speed)
    {

        if (Vector3.Distance(player1.Cube.transform.position, target.transform.position) > distanceToStop && Vector3.Distance(player1.Cube.transform.position, target.transform.position) < distanceMax)
        {

            Vector2 direction = target.transform.position - player.transform.position;
            Debug.Log(direction);
            var rigidbody = target.GetComponent<Rigidbody2D>();
            Debug.Log(direction * speed);
            Debug.Log(rigidbody);
            rigidbody.AddForce((direction * speed) * -1, ForceMode2D.Impulse);
        }
    }
}
