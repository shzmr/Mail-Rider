using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Written by Gemesil 1/30/2021 */
public class UltimateBulletHell : Shooting {

    [Header ("Settings")]
    [SerializeField]
    float spinSpeed = 500f;
    public bool canGenerate = true; // used to prevent the script from instantiating projectiles before the coroutine is over
    public int projPerShot = 1; // amount of projectiles per shot

    [Header ("Spinning Side Settings")]
    public float switchSideTimer = 0.3f; // the time in seconds between each side switch
    public bool enableSwitch = true; // enable the switch shooting side mechanic
    public bool increaseSpin = true;
    public float switchSideOffset = 0.01f;
    bool switchSide = true; // for internal coroutine purposes
    GameObject temp;
    public GameObject projectile; // projectile to be shot

    [SerializeField]
    float projCooldownTime = 0.2f; // amount of seconds between each shot

    void Update () {

        // UPDATE CURRENT GAMEOBJECT
        float vertical = Mathf.Sin (Time.deltaTime * spinSpeed);
        float horizontal = Mathf.Cos (Time.deltaTime * spinSpeed);
        transform.Rotate (0, 0, spinSpeed * Time.deltaTime);
        //transform.Rotate (0, 0, horizontal * vertical);

        //transform.Rotate (0, 0, spinSpeed * Time.fixedUnscaledDeltaTime);

        // GENERATE PROJECTILES
        if (canGenerate) {
            for (int i = 0; i <= projPerShot; i++) {
                temp = Instantiate (projectile, gameObject.transform.position, gameObject.transform.rotation);
                temp.transform.parent = gameObject.transform;
                Destroy (temp, 6);
            }
            canGenerate = !canGenerate;
            StartCoroutine (ProjectileCooldown ());
        }

        // INCREASE SPIN SIDE CHANGE OVER TIME
        if (increaseSpin) {
            switchSideTimer += switchSideOffset * Time.deltaTime;
            if (switchSideTimer > 1) {
                switchSideTimer = 0.3f;
            }
        }

        // SWITCH SPIN SIDE
        if (switchSide & enableSwitch) {
            switchSide = !switchSide;
            StartCoroutine (switchSpinningSide ());
        }
    }

    IEnumerator ProjectileCooldown () {
        yield return new WaitForSeconds (projCooldownTime);

        canGenerate = !canGenerate;
    }

    IEnumerator switchSpinningSide () {
        yield return new WaitForSeconds (switchSideTimer);

        switchSide = !switchSide;
        spinSpeed *= -1;
    }
}