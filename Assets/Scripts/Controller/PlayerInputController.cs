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
      
        CallMoveEvent(moveInput); //ȣ��(������ �ֵ����� ����)
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        //��ũ�� ��ǥ�� ������ǥ�� �����ؾ���
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

        //���콺�� ����� ��ġ�� - �� ��ġ�� ���� �� ���ͷ� ���ϴ� ���Ⱚ�� ���´� 
        newAim = (worldPos - (Vector2)transform.position).normalized;

        //magintude : ũ�� 
        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim); 
        }
    }
}
