using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;

    private float timer;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.15f)
        {
            var t = player.Cube.transform.position.x;

            if (player.Team.Inverteddamage)
            {
                t *= -1;
            }

            if (t <= -1)
            {
                ;
                if (player.Health <= 0 || (player.Health - 2) <= 0)
                {
                    player.Health = 0;
                    player.IsAlive = false;
                    player.Cube.GetComponent<Renderer>().material.color = Color.black;
                }
                else
                {
                    var damage = (int)Math.Round(2f * (t * -1) / 5);
                    player.Health -= damage;
                }

            }
            else if (t >= 1)
            {
                if (player.Health >= 100 || (player.Health += 1) >= 100)
                {
                    player.Health = 100;
                }
                else
                {
                    player.Health += (int)Math.Round(1f * t / 5);
                }



            }
            timer = 0;
        }

        if (player.IsAlive)
        {
            //player.Cube.transform.Translate(10 * Input.GetAxis(player.x) * Time.deltaTime, 0f, 10 * Input.GetAxis(player.y) * Time.deltaTime);
            player.Cube.transform.Translate(speed * Input.GetAxis(player.x) * Time.deltaTime, speed * Input.GetAxis(player.y) * Time.deltaTime, 0);

        }
        
    }
}
