using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public float Speed { get; private set; }

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator animator;

    private void Start()
    {
        StateController.PlayerStateChanged += AllowMovement;

        Speed = speed;
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Speed != 0)
            sprite.flipX = true;

        if (Input.GetKeyDown(KeyCode.D) && Speed != 0)
            sprite.flipX = false;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        body.velocity = new Vector2(x * Speed, y * Speed);
        animator.SetBool("run", (Mathf.Abs(x) > 0f || Mathf.Abs(y) > 0f) && Speed != 0);
    }

    public void AllowMovement(PlayerState state)
    {
        if (state == PlayerState.Active)
            Speed = speed;
        else
            Speed = 0;
    }
}
