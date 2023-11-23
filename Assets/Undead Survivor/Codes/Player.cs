using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed; // 속도 선언
    Rigidbody2D rigid;  // 중력 선언
    SpriteRenderer spriter; // 좌우반전에 쓸 스프라이터 렌더러 선언 
    Animator anim; // 애니메이터 선언
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // 함수 선언
        spriter = GetComponent<SpriteRenderer>(); // 함수 선언
        anim = GetComponent<Animator>(); // 함수 선언
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);// 속도제어
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); // 애니메이션 설정

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;//좌우반전 제어
        }
    }
}
