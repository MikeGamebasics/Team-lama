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
    private float ChangeColorTimer;
    private GameObject particle;

    public float speed;
    Text PlayerHP;
    private string whichPlayerHP;
    Color PlayerHPColor;
    int OldPlayerHP;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        OldPlayerHP = 100;
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

            UpdatePlayerHealth("P1HP");
        }
        else if (player.Cube.tag == "Vampire")
        {


            if (player.collision)
            {
                DoDamage();
            }
            else
            {
                DoHeal();
            }

            UpdatePlayerHealth("P2HP");
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
        if (player.IsAlive)
        {
            player.collision = false;
            DamageTimer += Time.deltaTime;

            if (DamageTimer >= 0.1f)
            {

                if (player.Health <= 0 || (player.Health - 2) <= 0)
                {
                    player.Health = 0;
                    player.IsAlive = false;
                    player.Cube.GetComponent<Renderer>().material.color = Color.black;
                    PlayDeathSound();
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
    }

    private void DoHeal()
    {
        HealTimer += Time.deltaTime;

        if (player.IsAlive)
        {
            if (HealTimer >= 0.9f)
            {
                player.collision = false;
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

    private void UpdatePlayerHealth(string whichPlayerHP)
    {
        PlayerHP = GameObject.Find(whichPlayerHP).GetComponent<Text>();
        PlayerHP.text = player.Health.ToString() + "%";

        ChangeColorTimer += Time.deltaTime;

        if (player.IsAlive)
        {
            if (ChangeColorTimer >= 0.15f)
            {
                PlayerHP.color = ChangePlayerHPColor(OldPlayerHP);
                ChangeColorTimer = 0;
                OldPlayerHP = player.Health;
            }
        }

    }

    private Color ChangePlayerHPColor(int oldNumber)
    {
        Color color;
        if (oldNumber < player.Health)
        {
            color = Color.green;
        }
        else if (oldNumber > player.Health)
        {
            color = Color.red;
        }
        else color = Color.white;
        return color;
    }

    private void PlayDeathSound()
    {
        if (player.Cube.tag == "Vampire")
        {
            FindObjectOfType<AudioManager>().Play("Death");
        }
        else if (player.Cube.tag == "Hunter")
        {
            FindObjectOfType<AudioManager>().Play("Consuela");
        }
    }
}
