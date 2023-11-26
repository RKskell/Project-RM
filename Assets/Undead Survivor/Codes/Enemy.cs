using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Spawner;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float health;
    public float maxhelth;
    public RuntimeAnimatorController[] animCon;//애니메이터 컨트롤러
    public Rigidbody2D target;

    bool isLive;//몬스터의 생존여부를 판단하는 islive 변수

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    
    void FixedUpdate()
    {
        if (!isLive)// 몬스터가 살아있지않으면 return
            return;


        Vector2 dirvec = target.position - rigid.position; //몬스터 위치
        Vector2 nextvec = dirvec.normalized * speed * Time.fixedDeltaTime;//타겟의 위치(플레이어)
        rigid.MovePosition(rigid.position + nextvec); //플레이어 키입력값 + 몬스터의 방향값을 더한이동
        rigid.velocity = Vector2.zero;//물리속도가 이동에 영향을 주지않도록 속도제거



    }

    void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
    void OnEnable()//플레이어 넣으면 합칠것 (자동으로 타겟을 플레이어로 지정하는곳
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); 
        isLive = true;
        health = maxhelth;

    }


    public void Init(SpawnData data)//레벨에따른 몬스터 상태 변경
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxhelth = data.health;
        health = data.health;
    }

}
