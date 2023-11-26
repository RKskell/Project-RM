using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;



//player아래의 
//Spawner에 스크립트로 넣을것


//https://www.youtube.com/watch?v=A7mfPH8jyBE&list=PLO-mt5Iu5TeZF8xMHqtT_DhAPKmjF6i3x&index=8
//영상31분30초 부터 보고 스폰포인트(point) 정하기


public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPoint;
    int level;
    public SpawnData[] spawnData;

    float timer;
    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.GameTime / 10f),spawnData.Length-1);         

        if (timer > spawnData[level].spawnTime)
        { //레벨 0일때 소환타이밍 0.5초 시간이 지나면 0.2
            timer = 0;
            Spawn();
        }
    }



        void Spawn()//spawn 함수 선언 (몬스터 한마리 소환
        {
            GameObject enemy = GameManager.instance.pool.Get(0);//레벨에 따라 몬스터 소환량증가
                                                                //enemy.transform.position = spawnPoint = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
                                                                //spawnPont 만들고 주석지울것(영상 31분 30초)
        enemy.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
        }
    

}

    [System.Serializable] ///SpawnData 직렬화 선언
    public class SpawnData
    {
        public float spawnTime;  //몬스터 스폰 타이밍 
        public int spriteType;
        public int health;       //몬스터 체력
        public float speed;      //몬스터 이동속도
    }
