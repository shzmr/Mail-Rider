using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellGeneratorConsistant : Shooting {
    private float angle = 0f;
    public GameObject projPrefab; // projectile prefab
    public float projCooldown = 1f; // cooldown between projectiles
    public int projPerShot = 1; // amount of projectiles per shot
    public int angleOffset = 10;
    public bool enableMultiple = true;
    public bool enableSpinning = false;
    public float spinSpeed = 200f;

    [Header ("Offsets")]
    public float offsetX = 100f;
    public float offsetY = 200f;

    void Start () {
        InvokeRepeating ("FirePattern", 0f, projCooldown);
    }

    void Update () {
        if (enableSpinning) {
            transform.Rotate (0, 0, spinSpeed * Time.deltaTime);
        }
    }

    private void FirePattern () {
        float projDirX = transform.position.x * Mathf.Sin ((angle * Mathf.PI) / 180f);
        float projDirY = transform.position.y * Mathf.Cos ((angle * Mathf.PI) / 180f);

        Vector3 projMoveVector = new Vector3 (projDirX, projDirY, 0f);
        Vector2 projDir = (projMoveVector - transform.position).normalized;

        if (enableMultiple) {
            for (int i = 0; i <= projPerShot; i++) {
                GameObject proj = Instantiate (projPrefab, transform.position, Quaternion.Euler (offsetX, offsetY, angle * (i * angleOffset)));
                proj.transform.parent = gameObject.transform;
                Destroy (proj, 6);
            }
        } else {
            GameObject proj = Instantiate (projPrefab, transform.position, Quaternion.Euler (offsetX, offsetY, angle));
            proj.transform.parent = gameObject.transform;
            Destroy (proj, 6);
        }
        //proj.GetComponent<> ().SetMoveDirection (projDir);

        angle += 50f;
    }

}