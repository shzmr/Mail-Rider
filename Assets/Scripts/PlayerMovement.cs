using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : Damageable
{
    public float moveSpeed = 1;
    public new Camera camera;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vertical = Input.GetAxis("Vertical") * Vector3.up * moveSpeed * Time.deltaTime;
        Vector3 horizontal = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;
        transform.Translate(vertical + horizontal);
    }
}

