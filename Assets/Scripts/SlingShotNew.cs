using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class SlingShotNew : MonoBehaviour 
{

    public float maxStretch = 3f;

    public LineRenderer front;
    public LineRenderer back;

    private SpringJoint2D spring;
    private bool clickedOn;
    private Transform slingshot;

    private Ray rayToMouse;
    private Ray leftToProjectile;
    private float maxStretchSqr;
    private float circleRadius;
    private Vector2 prevVelocity;

    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        slingshot = spring.connectedBody.transform;
    }

    void Start()
    {
        LineRendererSetup();
        rayToMouse = new Ray(slingshot.position, Vector3.zero);
        leftToProjectile = new Ray(front.transform.position, Vector3.zero);
        maxStretchSqr = maxStretch * maxStretch;
        CircleCollider2D circle = collider2D as CircleCollider2D;
        circleRadius = circle.radius;
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
                Destroy(spring);
                rigidbody2D.velocity = prevVelocity;
            }

            if (!clickedOn)
                prevVelocity = rigidbody2D.velocity;

            LineRendererUpdate();
        }
        else
        {
            front.enabled = false;
            back.enabled = false;
        }
    }

    void LineRendererSetup()
    {
        front.SetPosition(0, front.transform.position - new Vector3 (-0.25f, 0, 0));
        back.SetPosition(0, back.transform.position - new Vector3(-0.20f, 0, 0));

    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }

    void OnMouseUp()
    {
        spring.enabled = true;
        rigidbody2D.isKinematic = false;
        clickedOn = false;
    }

    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 slingToMouse = mouseWorldPoint - slingshot.position;
        if (slingToMouse.sqrMagnitude > maxStretchSqr)
        {
            rayToMouse.direction = slingToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }

        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint - new Vector3(0,0,3);
    }

    void LineRendererUpdate()
    {
        Vector2 slingToProjectile = transform.position - front.transform.position;
        leftToProjectile.direction = slingToProjectile;
        Vector3 holdPoint = leftToProjectile.GetPoint(slingToProjectile.magnitude + circleRadius);
        front.SetPosition(1, holdPoint - new Vector3(0, 0, 0));
        back.SetPosition(1, holdPoint - new Vector3(0,0,-2));
    }


}

