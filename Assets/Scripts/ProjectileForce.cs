using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileForce : Damaging {

    private Renderer rend;
    private Vector3 center;
    private float radius;

    [SerializeField]
    float projSpeed = 4f;

    void Start () {
        rend = GetComponent<Renderer> ();
    }

    void Update () {
        AddRandomForce ();
    }

    // Force in a random direction
    void AddRandomForce () {
        gameObject.transform.Rotate (0, gameObject.transform.rotation.y, 0);
        gameObject.transform.position += transform.right * Time.deltaTime * projSpeed;
    }

    // Shoot projectiles out in a circular pattern
    void AddCircularForce () {
        center = rend.bounds.center;
        radius = rend.bounds.extents.magnitude;
        Vector2 direction = gameObject.transform.position.normalized;
        Vector2 placeToSpawn = direction * radius;
    }

    protected override void OnDamagingCollision(GameObject go)
    {
        Destroy(gameObject);
    }
}
