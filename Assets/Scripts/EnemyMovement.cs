using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float verticalLimit = 4;
    public float verticalMoveSpeed = 1;
    public float horizontalMoveSpeed = 1;
    public float time { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * verticalMoveSpeed;
        float verticalMove = verticalLimit * Mathf.Sin(time);
        float horizontalMove = -horizontalMoveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + horizontalMove, verticalMove);
        if (time >= 2 * Mathf.PI) time = 0;
    }
}

