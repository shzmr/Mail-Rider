using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpinner : MonoBehaviour {

    [Header ("Speed Settings")]
    [SerializeField]
    float spinSpeed = 500f;
    [SerializeField]
    float baseSpinAmount = 20f;

    [Header ("Projectile Direction Side")]
    public float switchSideTimer = 1f; // the time between each side switch
    public bool enableSwitch = false; // enable the switch shooting side mechanic
    bool switchSide = true; // for internal coroutine purposes

    void Update () {
        transform.Rotate (0, 0, spinSpeed * Time.deltaTime);
        if (switchSide & enableSwitch) {
            switchSide = !switchSide;
            StartCoroutine (SwitchShootingSide ());
        }
    }

    IEnumerator SwitchShootingSide () {
        yield return new WaitForSeconds (switchSideTimer);

        switchSide = !switchSide;
        spinSpeed *= -1;
    }
}
