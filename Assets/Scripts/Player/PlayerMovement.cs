using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public SpriteRenderer SpriteRenderer;

    public float Speed;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (!SpriteRenderer)
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseState.Instance.CurrentState == PauseState.State.WALKING)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            rigidbody2D.velocity = new Vector2(h, v) * Speed;
            if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1f)
            {
                SpriteRenderer.flipX = rigidbody2D.velocity.x > 0;
            }
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}