using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing = 0.5f; //�ε巴�� �̵��� ��

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        //�ΰ��� ���� ���̸� ���������Ͽ� �ε巴�� �̵��ϴµ� ���ȴ� 
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing); 
    }

}
