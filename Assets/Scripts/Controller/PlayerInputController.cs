using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
      
        CallMoveEvent(moveInput); //호출(구독한 애들한테 전달)
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        //스크린 좌표를 월드좌표로 변경해야함
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

        //마우스의 월드상 위치를 - 내 위치를 빼면 그 벡터로 향하는 방향값이 나온다 
        newAim = (worldPos - (Vector2)transform.position).normalized;

        //magintude : 크기 
        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim); 
        }
    }
}
