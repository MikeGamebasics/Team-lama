using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Player player;

    private float HealTimer;
    private float DamageTimer;
    private GameObject particle;

    public float speed;
    Text PlayerHP;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Cube.tag == "Hunter")
        {


            if (player.collision)
            {
                DoHeal();
            }
            else
            {
                DoDamage();
            }

            PlayerHP = GameObject.Find("P1HP").GetComponent<Text>();
            PlayerHP.text = player.Health.ToString() + "%";
        }
        else if(player.Cube.tag =="Vampire")
        {


            if (player.collision)
            {
                DoDamage();
            }
            else
            {
                DoHeal();
            }

            PlayerHP = GameObject.Find("P2HP").GetComponent<Text>();
            PlayerHP.text = player.Health.ToString() + "%";
        }

    }

    void FixedUpdate()
    {
        if (player.IsAlive)
        {
            player.Cube.transform.Translate(speed * Input.GetAxis(player.x) * Time.deltaTime, speed * Input.GetAxis(player.y) * Time.deltaTime, 0);

        }

    }


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "spot")
        {
            player.collision = true;
        }
    }

    private void DoDamage()
    {
        player.collision = false;
        DamageTimer += Time.deltaTime;

        if (DamageTimer >= 0.15f)
        {

            if (player.Health <= 0 || (player.Health - 2) <= 0)
            {
                player.Health = 0;
                player.IsAlive = false;
                player.Cube.GetComponent<Renderer>().material.color = Color.black;
            }
            else
            {
                player.Health -= 2;
                particle = Instantiate(player.Particle) as GameObject;
                particle.transform.position = player.transform.position;
                
            }



            DamageTimer = 0;
        }
    }

    private void DoHeal()
    {
        player.collision = false;
        HealTimer += Time.deltaTime;

        if (player.IsAlive)
        {
            if (HealTimer >= 0.15f)
            {

                if (player.Health >= 100 || (player.Health += 1) >= 100)
                {
                    player.Health = 100;
                }
                else
                {
                    player.Health += 1;
                }
                HealTimer = 0;
            }
        }

    }
}
