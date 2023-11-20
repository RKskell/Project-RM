using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");// �¿��̵�
        inputVec.y = Input.GetAxisRaw("Vertical");// �����̵�
    }
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);// �ӵ�����
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
