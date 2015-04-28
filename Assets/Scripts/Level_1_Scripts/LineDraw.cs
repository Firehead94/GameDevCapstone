using UnityEngine;
using System.Collections;

public class LineDraw {

    public LineRenderer front;
    public LineRenderer back;

    public Ray rayToMouse;
    public Ray leftToProjectile;

    public float circleRadius;
    GameObject trans;

    public LineDraw(GameObject trans)
    {
        this.trans = trans;
        CircleCollider2D circle = trans.collider2D as CircleCollider2D;
        circleRadius = circle.radius;
    }

    public void LineRendererSetup()
    {
        front.SetPosition(0, front.transform.position - new Vector3(-0.25f, 0, 0));
        back.SetPosition(0, back.transform.position - new Vector3(-0.20f, 0, 0));

    }

    public void LineRendererUpdate()
    {
        Vector2 slingToProjectile = trans.transform.position - front.transform.position;
        leftToProjectile.direction = slingToProjectile;
        Vector3 holdPoint = leftToProjectile.GetPoint(slingToProjectile.magnitude + circleRadius);
        front.SetPosition(1, holdPoint - new Vector3(0, 0, 0));
        back.SetPosition(1, holdPoint - new Vector3(0, 0, -2));
    }

}
