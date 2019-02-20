using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class PullController : MonoBehaviour
{

    public Player player1;
    public Player player2;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            if (Input.GetKey(KeyCode.T))
            {
                Debug.Log("Fire1");
                FollowTargetWitouthRotation(player2.Cube, 1f, 1);
            }

            timer = 0f;
        }

    }

    void FollowTargetWitouthRotation(GameObject target, float distanceToStop, float speed)
    {

        if (Vector3.Distance(player1.Cube.transform.position, target.transform.position) > distanceToStop)
        {
            
            Vector3 direction = target.transform.position - player1.Cube.transform.position;
            Debug.Log(direction);
            var rigidbody = target.GetComponent<Rigidbody>();
            Debug.Log(direction * speed);
            Debug.Log(rigidbody);
            rigidbody.AddForce(direction * speed);
        }
    }
}
