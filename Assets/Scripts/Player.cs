﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Army armyScript;

    public float moveS = 1000.0f;

    Rigidbody2D rigidB;
    Animator anim;

    [SerializeField]
    private float backwardsMod;
    private float currBackMod;

    [SerializeField]
    GameObject Win;

    [SerializeField]
    GameObject Pause;

    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        armyScript = GetComponent<Army>();
    }

    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");

        //                  PAUSE

        if (Input.GetKey(KeyCode.P))  //Se Pause estiver disabled -> able
        {
            Pause.SetActive(true);
            Debug.Log("Pause!");
        }


            Vector2 currentVelocity = rigidB.velocity;

        currentVelocity = new Vector2(xAxis * moveS, currentVelocity.y);

        rigidB.velocity = currentVelocity * armyScript.speedModifier * currBackMod;


       
        

    }

    private void Update()
    {
        Vector2 currentVelocity = rigidB.velocity;

        if (currentVelocity.x < 0.0f)
        {
            currBackMod = backwardsMod;
        }
        else
            currBackMod = 1;

        anim.SetFloat("AbsVelocityX", Mathf.Abs(currentVelocity.x));
    }


    //                       WIN

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GOAL")
        {
            Win.SetActive(true);
        }
        Debug.Log(tag);
    }
}
