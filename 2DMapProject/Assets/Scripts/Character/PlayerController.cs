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
        // 마우스 위치를 스크린 좌표로 가져옵니다.
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        // 마우스 위치를 월드 좌표로 변환합니다.
        Vector2 mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);

        // 마우스 위치와 캐릭터 위치를 비교하여 스프라이트를 반전시킵니다.
        if (mouseWorldPosition.x < transform.position.x)
        {
            // 마우스가 캐릭터의 왼쪽에 있을 때
            spriteRenderer.flipX = true;
        }
        else
        {
            // 마우스가 캐릭터의 오른쪽에 있을 때
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
