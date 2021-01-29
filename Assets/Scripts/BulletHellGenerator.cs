using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellGenerator : MonoBehaviour {

    public GameObject projectile; // projectile to be shot
    GameObject temp;
    public bool canGenerate = true; // used to prevent the script from instantiating projectiles before the coroutine is over

    [SerializeField]
    float projCooldownTime = 0.2f; // amount of seconds between each shot

    void Start () {
        transform.Rotate (0, gameObject.transform.rotation.y, 0);
    }
    void Update () {
        if (canGenerate) {
            temp = Instantiate (projectile, gameObject.transform.position, gameObject.transform.rotation);
            Destroy (temp, 6);
            canGenerate = false;
            StartCoroutine (ShootingCooldown ());
        }
    }

    IEnumerator ShootingCooldown () {
        yield return new WaitForSeconds (projCooldownTime);

        canGenerate = true;
    }
}