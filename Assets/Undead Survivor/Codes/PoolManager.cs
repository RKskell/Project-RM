using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩 보관변수
    public GameObject[] prefabs;


    // 풀 담당 리스트
    List<GameObject>[] pools;


    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();

        }

    }
    public GameObject Get(int index)
    {
        GameObject select = null;
        //선택한 풀에 놀고(비활성화된) 있는 게임오브젝트 접근
        //발견하면 select 변수에 할당

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)//아이템이 비활성화인지 활성화인지 확인
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        //못찾았다면
        //새롭게 생성하고 select 변수에 할당
        if (select == null)
        {
            select = Instantiate(prefabs[index], transform);//게임오브젝트를 복제해서 반환
            pools[index].Add(select);

        }



        return select;
    }



}
