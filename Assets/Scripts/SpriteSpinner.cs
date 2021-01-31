using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpinner : MonoBehaviour {

    [Header ("Speed Settings")]
    [SerializeField]
    float spinSpeed = 500f;

    [Header ("Spinning Side Settings")]
    public float switchSideTimer = 1f; // the time between each side switch
    public bool enableSwitch = false; // enable the switch shooting side mechanic
    bool switchSide = true; // for internal coroutine purposes

    void Update () {
        transform.Rotate (0, 0, spinSpeed * Time.deltaTime);
        if (switchSide & enableSwitch) {
            switchSide = !switchSide;
            StartCoroutine (switchSpinningSide ());
        }
    }

    IEnumerator switchSpinningSide () {
        yield return new WaitForSeconds (switchSideTimer);

        switchSide = !switchSide;
        spinSpeed *= -1;
    }
}
