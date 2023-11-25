using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision) //맵 재배치 이벤트 로직, 플레이어의 Area와 충돌시 재배치
    {
        if (!collision.CompareTag("Area")) //Area 태그가 아닐시 return
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position; //거리 구하기 위해 타일맵 위치를 저장
        Vector3 myPos = transform.position; //거리 구하기 위해 플레이어 위치 저장
        float diffX = Mathf.Abs(playerPos.x - myPos.x); //x축 거리 계산(Mathf.Abs : 음수를 양수로 만드는 절대값 함수) 
        float diffY = Mathf.Abs(playerPos.y - myPos.y); //y축 거리 계산

        Vector3 playerDir = GameManager.instance.player.inputVec; //플레이어 이동 방향을 저장
        float dirX = playerDir.x < 0 ? -1 : 1; //x축 이동 방향 계산
        float dirY = playerDir.y < 0 ? -1 : 1; //y축 이동 방향 계산

        switch (transform.tag) //태그 별로 로직 나누기
        {
            case "Ground": //맵 태그
                if(diffX > diffY) //어느 방향으로 이동하는지 계산해 타일 이동 [X축]
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY) //[Y축]
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy": //적 태그

                break;
        }
    }
}
