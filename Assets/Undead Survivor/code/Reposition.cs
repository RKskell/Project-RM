using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision) //�� ���ġ �̺�Ʈ ����, �÷��̾��� Area�� �浹�� ���ġ
    {
        if (!collision.CompareTag("Area")) //Area �±װ� �ƴҽ� return
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position; //�Ÿ� ���ϱ� ���� Ÿ�ϸ� ��ġ�� ����
        Vector3 myPos = transform.position; //�Ÿ� ���ϱ� ���� �÷��̾� ��ġ ����
        float diffX = Mathf.Abs(playerPos.x - myPos.x); //x�� �Ÿ� ���(Mathf.Abs : ������ ����� ����� ���밪 �Լ�) 
        float diffY = Mathf.Abs(playerPos.y - myPos.y); //y�� �Ÿ� ���

        Vector3 playerDir = GameManager.instance.player.inputVec; //�÷��̾� �̵� ������ ����
        float dirX = playerDir.x < 0 ? -1 : 1; //x�� �̵� ���� ���
        float dirY = playerDir.y < 0 ? -1 : 1; //y�� �̵� ���� ���

        switch (transform.tag) //�±� ���� ���� ������
        {
            case "Ground": //�� �±�
                if(diffX > diffY) //��� �������� �̵��ϴ��� ����� Ÿ�� �̵� [X��]
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY) //[Y��]
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy": //�� �±�

                break;
        }
    }
}
