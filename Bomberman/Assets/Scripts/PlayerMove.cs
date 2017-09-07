﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Vector3 playerInput = new Vector3(0, 0, 0);
    Vector3 lastInput;
    Rigidbody2D rb;
    public Animator anim;
    float moveSpeed = 2.5f;
    float lastBombTime;
    bool moving;

    int rangePowerUp = 0;

    public GameObject BombPrefab;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        moving = false;
        
        playerInput = new Vector3(0, 0 , 0);
        if (Input.GetKey("up")) {
            playerInput.y += 1;
        }
        if (Input.GetKey("down"))
        {
            playerInput.y -= 1;
        }
        if (Input.GetKey("left"))
        {
            playerInput.x -= 1;
            
        }
        if (Input.GetKey("right"))
        {
            playerInput.x += 1;
        }
        
        if (playerInput.x > 0 || playerInput.x < 0 || playerInput.y > 0 || playerInput.y < 0)
        {
            lastInput = playerInput;
            moving = true;
        }
        
        

        Vector3 movement = playerInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement );

        anim.SetFloat("XSpeed", playerInput.x);
        anim.SetFloat("YSpeed", playerInput.y);

        anim.SetFloat("LastXSpeed", lastInput.x);
        anim.SetFloat("LastYSpeed", lastInput.y);

        anim.SetBool("isMoving", moving);

        if (Input.GetKeyDown("space")) {
            print("drop bomb");
            if (Time.time - lastBombTime < 1)
            {

            }
            else {
                lastBombTime = Time.time;

                Vector3 bombLocation = new Vector3();
                bombLocation.x = Mathf.Round(transform.position.x);
                bombLocation.y = Mathf.Round(transform.position.y);
                //spawn bomb
                GameObject bomb = Instantiate(BombPrefab, bombLocation, Quaternion.identity) as GameObject;
                bomb.GetComponent<Bomb>().range += rangePowerUp;
            }
        }

    }
}
