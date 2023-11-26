using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;



//player아래의 
//Spawner에 스크립트로 넣을것



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
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.GameTime / 10f), spawnData.Length - 1);

        if (timer > spawnData[level].spawnTime)
        { //레벨 0일때 소환타이밍 0.5초 시간이 지나면 0.2
            timer = 0;
            Spawn();
        }
    }



    void Spawn()//spawn 함수 선언 (몬스터 한마리 소환
    {
        GameObject enemy = GameManager.instance.pool.Get(0);    //레벨에 따라 몬스터 소환량증가                           
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
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
