using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed; // �ӵ� ����
    Rigidbody2D rigid;  // �߷� ����
    SpriteRenderer spriter; // �¿������ �� ���������� ������ ���� 
    Animator anim; // �ִϸ����� ����
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); // �Լ� ����
        spriter = GetComponent<SpriteRenderer>(); // �Լ� ����
        anim = GetComponent<Animator>(); // �Լ� ����
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);// �ӵ�����
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); // �ִϸ��̼� ����

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;//�¿���� ����
        }
    }
}
