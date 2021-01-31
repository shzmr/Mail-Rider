using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissiles : Damaging {
    private Rigidbody2D rb2d;
    public GameObject player;
    public float projSpeed = 5f;

        public float speed = 0.02f;
    private Transform target;
    private float moveSpeedFollow = 1f;
    public float rotateSpeed = 200f;

    void Start () {
        // Add + 1 to player's last known position so bullet appears to float above ground.
        Vector3 playerPos = new Vector3 (player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);

        // Aim bullet in player's direction.
        transform.rotation = Quaternion.LookRotation (playerPos);

        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        // // Get player direction and normalize it so it doesn't exceed 1.
        // Vector2 aim = (player.transform.position - transform.position).normalized;
        // // Add force based on that direction, modifying it as needed.
        // rb2d.AddForce (aim * projSpeed);

        //Vector3 direction = (Vector3) target.position - rb2d.position;
        //direction.Normalize ();
        //Vector3 rotateAmount = Vector3.Cross (direction, transform.forward);
        //rb2d.angularVelocity = -rotateAmount * rotateSpeed;
        //rb2d.velocity = transform.forward * speed;

    }
}