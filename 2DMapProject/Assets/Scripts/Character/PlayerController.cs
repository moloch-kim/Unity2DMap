using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera camera;
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    private static readonly int isRun = Animator.StringToHash("isRun");
    

    private void Awake()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // ���콺 ��ġ�� ��ũ�� ��ǥ�� �����ɴϴ�.
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ�մϴ�.
        Vector2 mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);

        // ���콺 ��ġ�� ĳ���� ��ġ�� ���Ͽ� ��������Ʈ�� ������ŵ�ϴ�.
        if (mouseWorldPosition.x < transform.position.x)
        {
            // ���콺�� ĳ������ ���ʿ� ���� ��
            spriteRenderer.flipX = true;
        }
        else
        {
            // ���콺�� ĳ������ �����ʿ� ���� ��
            spriteRenderer.flipX = false;
        }
    }

    public void OnMove(InputValue value)
    {
        anim.SetBool("isRun", true);
        moveInput  = value.Get<Vector2>().normalized;
    }

    void OnControllChanged(InputValue value)
    {
        anim.SetBool("isRun", false);
    }


    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }
    
}
