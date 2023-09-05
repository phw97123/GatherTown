using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing = 0.5f; //부드럽게 이동할 값

    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        //두개의 벡터 사이를 선형보간하여 부드럽게 이동하는데 사용된다 
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing); 
    }

}
