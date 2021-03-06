﻿using System;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

class Shot : MonoBehaviour 
{

    public float maxStretch = 3f;

    LineDraw lines;

    public SpringJoint2D spring;
    private bool clickedOn;
    private Transform slingshot;

    private float maxStretchSqr;

    private Vector2 prevVelocity;
    private Controller control;

    public GameObject explosion;

    void Awake()
    {
        
    }

	// Initiates the mechanics for the slingshot
    void Start()
    {
        lines = new LineDraw(gameObject);
        control = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Controller>();
        spring = GetComponent<SpringJoint2D>();
        lines.front = GameObject.FindGameObjectWithTag("front").GetComponent<LineRenderer>();
        lines.back = GameObject.FindGameObjectWithTag("back").GetComponent<LineRenderer>();
        spring.connectedBody = GameObject.FindGameObjectWithTag("front").GetComponent<Rigidbody2D>();
        slingshot = spring.connectedBody.transform;

        lines.rayToMouse = new Ray(slingshot.position, Vector3.zero);
        lines.leftToProjectile = new Ray(lines.front.transform.position, Vector3.zero);
        maxStretchSqr = maxStretch * maxStretch;
        rigidbody2D.isKinematic = true;
        spring.enabled = true;
        lines.front.enabled = true;
        lines.back.enabled = true;
        lines.LineRendererSetup();
    }

    void FixedUpdate()
    {

    }

    void Update()
    {
        
        if (clickedOn)
            Dragging();
        if (spring != null)
        {
            if (!rigidbody2D.isKinematic && prevVelocity.sqrMagnitude > rigidbody2D.velocity.sqrMagnitude)
            {
                spring.enabled = false;
                lines.front.enabled = false;
                lines.back.enabled = false;
                rigidbody2D.velocity = prevVelocity;            
            }

            if (!clickedOn)
            {
                prevVelocity = rigidbody2D.velocity;
                transform.Rotate(0, 0, -Time.deltaTime * 10 * rigidbody2D.velocity.sqrMagnitude);
            }


            lines.LineRendererUpdate();
        }
        else
        {
            lines.front.enabled = false;
            lines.back.enabled = false;
            
        }

    }

	//Activates slingshot
    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }
	//Slingshot release
    void OnMouseUp()
    {
        spring.enabled = true;
        rigidbody2D.isKinematic = false;
        clickedOn = false;
        
    }
	//Stretching out the slingshot based on the players mouse
    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 slingToMouse = mouseWorldPoint - slingshot.position;
        if (slingToMouse.sqrMagnitude > maxStretchSqr)
        {
            lines.rayToMouse.direction = slingToMouse;
            mouseWorldPoint = lines.rayToMouse.GetPoint(maxStretch);
        }

        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint - new Vector3(0,0,3);
    }


	//If an alien is hit by standard ammo then destroy it
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (this.gameObject.tag.Equals("ammo"))
        { 
            if (coll.gameObject.tag.Equals("alien") && !gameObject.GetComponent<Rigidbody2D>().isKinematic)
            {
                Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(coll.gameObject);
                control.SetScore(1);
                Destroy(this.gameObject);
            }
        }
		//If an enemy is hit by a capsule then cause bounce from the impact
        if (this.gameObject.tag.Equals("ammoCap"))
        {
            if (coll.gameObject.tag.Equals("alien") && !gameObject.GetComponent<Rigidbody2D>().isKinematic)
            {
                Destroy(this.gameObject);
                control.SetHP(1);
            }

        }
        
    }

	//If an enemy hits the game level bounds then destory that prefab
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("spawnnew") && !clickedOn)
        {
            control.shouldSpawn = true;
        }

        if (coll.gameObject.tag.Equals("bounds"))
        {
            Destroy(gameObject);
        }
    }


   

}




