using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
-Made by Gemesil 29/1/2021 all credit is due please thank me when you can :*)-

This script controls the projectile rotation, speed, velocity and so on.
You can enable / disable features from the public booleans and change the speed
values from the public variables, everything is sorted via headers so it should
be easier to adjust from the editor. Have a nice day and good luck making this
work in your own project :D
*/

public class Projectile : Damaging {
    [Header ("Pattern Adjustment")]
    public float speed = 2f; // distance per update
    public float angle;
    public float acceleration; // change in speed per update
    public float maxSpeed; // clamp speed to this value
    public float angularVelocity; // change in angle per update
    public float spinSpeed = 400f;

    private Rigidbody2D rb2d;

    // UI Variables (FOR TESTING)
    [Header ("UI Variables")]
    public Slider spinSpeedUI;
    public Slider speedUI;
    public Slider accelerationUI;
    public Slider angularVelocityUI;
    public Slider maxSpeedUI;

    [Header ("Toggle Features")]
    public bool randomizeSpinSpeed = true;
    public bool enableSlowDown = true;
    public bool enableAcceleration = true;
    public bool enableAngularVelocity = true;
    public bool enableAngleChange = true;

    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    void Update () {

        // Spin
        transform.Rotate (0, 0, spinSpeed * Time.deltaTime);

        // Calculate speed
        var velocity = rb2d.velocity;
        speed = velocity.magnitude;

        if (enableAngleChange) {
            ChangeAngle ();
        }

        if (enableAcceleration) {
            transform.Translate (0, acceleration * Time.deltaTime, 0);
            if (speed < maxSpeed) {
                rb2d.angularVelocity += angularVelocity;
            }
        }

        if (enableSlowDown) {
            rb2d.velocity = rb2d.velocity * 0.9f;
        }
    }

    void FixedUpdate () {
        rb2d.AddForce (speed * Time.deltaTime * Vector2.right * angle, ForceMode2D.Force);

        if (enableAngularVelocity) {
            rb2d.AddTorque (angularVelocity);
        }
    }

    void ChangeAngle () {
        angle += angularVelocity;
    }

    protected override void OnDamagingCollision(GameObject go)
    {
        Destroy(gameObject);
    }
}