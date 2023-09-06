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
      
        if(manager.isAction == false) //��ȭ���̶�� �̵� X
        {
            CallMoveEvent(moveInput);//ȣ��(������ �ֵ����� ����)
        }
    }

    public void OnLook(InputValue value)
    {
        if(manager.isAction == false) //��ȭ���̶�� ������ȯ X
        {
            Vector2 newAim = value.Get<Vector2>();
            //��ũ�� ��ǥ�� ������ǥ�� �����ؾ���
            Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

            //���콺�� ����� ��ġ�� - �� ��ġ�� ���� �� ���ͷ� ���ϴ� ���Ⱚ�� ���´� 
            newAim = (worldPos - (Vector2)transform.position);

            //magintude : ũ�� 
            if (newAim.magnitude >= .9f)
            {
                CallLookEvent(newAim);
                PerformRaycast(newAim); //����ĳ����
            }
        }
    }

    public void OnAction(InputValue value) //F Ű�� ������ ��ȣ�ۿ�
    {
        if(scanObject != null) //������ ������Ʈ�� null�� �ƴϸ�
        {
            manager.Action(scanObject); 
        }
    }

    private void PerformRaycast(Vector2 raycastDirection) //����ĳ���� �ϴ� �Լ�
    {
        Vector2 raycastOrigin = transform.position;
        float raycastDistance = 1.0f;

        Debug.DrawRay(raycastOrigin, raycastDirection * 0.7f, new Color(0, 1, 0));

        LayerMask objectLayerMask = LayerMask.GetMask("Object");
        LayerMask npcLayerMask = LayerMask.GetMask("NPC");

        // "NPC" ���̾ ���� ����ĳ��Ʈ ����
        RaycastHit2D npcHit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance, npcLayerMask);

        if (npcHit.collider != null)
        {
            // �������� ���� "NPC" ���̾ �˻�
            scanObject = npcHit.collider.gameObject;
        }
        else
        {
            // ���������� ���� ���� "Object" ���̾�� "NPC" ���̾� �� �� �˻�
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
