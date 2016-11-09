﻿using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour
{

    Rigidbody2D rigid;
    Animator ballAnimator;
    float speed = 5.0f;
    Vector2 maxVel = new Vector2(20.0f, 0.0f);

	public GameObject soundHandler;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ballAnimator = GetComponent<Animator>();

		soundHandler = GameObject.FindGameObjectWithTag ("soundHandler");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float userInput = Input.GetAxis("Horizontal") * Time.deltaTime;
		if ((rigid.velocity.x < maxVel.x && userInput > 0) || (rigid.velocity.x > -maxVel.x && userInput < 0)) {
			rigid.velocity += new Vector2 (speed * userInput, 0.0f);

			soundHandler.GetComponent<SoundPlayer> ().playMovingKeyPressed();
		}

		if (rigid.velocity.x > 4 || rigid.velocity.x < -4) {
			ballAnimator.SetBool ("moving", true);
			soundHandler.GetComponent<SoundPlayer> ().playMovingSound();

		}
        else
        {
            ballAnimator.SetBool("moving", false);
        }
        //if(Input.anyKey)
        //    rigid.AddForce(new Vector2(0.0f, 15.0f));
        if (rigid.velocity.x > 5)
            speed = 25.0f;
    }
}
