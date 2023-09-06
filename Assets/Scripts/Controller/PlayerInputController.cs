using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;

    GameObject scanObject;

    public GameManager manager; 

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
      
        if(manager.isAction == false) //대화중이라면 이동 X
        {
            CallMoveEvent(moveInput);//호출(구독한 애들한테 전달)
        }
    }

    public void OnLook(InputValue value)
    {
        if(manager.isAction == false) //대화중이라면 방향전환 X
        {
            Vector2 newAim = value.Get<Vector2>();
            //스크린 좌표를 월드좌표로 변경해야함
            Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

            //마우스의 월드상 위치를 - 내 위치를 빼면 그 벡터로 향하는 방향값이 나온다 
            newAim = (worldPos - (Vector2)transform.position);

            //magintude : 크기 
            if (newAim.magnitude >= .9f)
            {
                CallLookEvent(newAim);
                PerformRaycast(newAim); //레이캐스팅
            }
        }
    }

    public void OnAction(InputValue value) //F 키를 누르면 상호작용
    {
        if(scanObject != null) //감지된 오브젝트가 null이 아니면
        {
            manager.Action(scanObject); 
        }
    }

    private void PerformRaycast(Vector2 raycastDirection) //레이캐스팅 하는 함수
    {
        Vector2 raycastOrigin = transform.position;
        float raycastDistance = 1.0f;

        Debug.DrawRay(raycastOrigin, raycastDirection * 0.7f, new Color(0, 1, 0));

        LayerMask objectLayerMask = LayerMask.GetMask("Object");
        LayerMask npcLayerMask = LayerMask.GetMask("NPC");

        // "NPC" 레이어에 대한 레이캐스트 수행
        RaycastHit2D npcHit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance, npcLayerMask);

        if (npcHit.collider != null)
        {
            // 겹쳐있을 때는 "NPC" 레이어만 검사
            scanObject = npcHit.collider.gameObject;
        }
        else
        {
            // 겹쳐져있지 않을 때는 "Object" 레이어와 "NPC" 레이어 둘 다 검사
            RaycastHit2D objectHit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance, objectLayerMask);

            if (objectHit.collider != null)
            {
                scanObject = objectHit.collider.gameObject;
            }
            else
            {
                scanObject = null;
            }
        }
    }
}
