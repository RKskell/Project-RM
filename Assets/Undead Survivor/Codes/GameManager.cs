using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //게임매니저 정적으로 변수 선언
    public Player player; //플레이어 변수 선언

    void Awake()
    {
        instance = this; //게임매니저 호출
    }
}
