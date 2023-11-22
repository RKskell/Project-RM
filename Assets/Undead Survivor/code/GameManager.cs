using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // public Player player;

    public float GameTime;
    public float maxGameTime = 2 * 10f;  //20초 
    

    public PoolManager pool;

    private void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        GameTime += Time.deltaTime;


        if (GameTime > maxGameTime)
        {
            GameTime = maxGameTime;
        }

    }

    }
