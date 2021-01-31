using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float verticalLimit = 4;
    public float verticalMoveSpeed = 1;
    public float horizontalMoveSpeed = 1;

    public Sprite open;
    Sprite closed;

    SpriteRenderer spriteRenderer;

    public float time { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null)
            closed = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * verticalMoveSpeed;
        float verticalMove = verticalLimit * Mathf.Sin(time);
        float horizontalMove = -horizontalMoveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + horizontalMove, verticalMove);
        if (time >= 2 * Mathf.PI) time = 0;
        if (Mathf.Cos(time) > 0 && spriteRenderer != null)
        {
            spriteRenderer.sprite = closed;
        }
        else if(open != null)
        {
            spriteRenderer.sprite = open;
        }
    }
}

