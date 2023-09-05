using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private Vector2 _movementDirection = Vector2.zero; 
    private Rigidbody2D _rigidbody;
    GameObject child = null; 

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();

        child = transform.GetChild(0).gameObject; 
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection); 
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move ; 
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;//5는 속도
        _rigidbody.velocity = direction; //가속도 처리

        bool isMoving = direction.magnitude > 0;
        //_controller.GetComponent<Animator>().SetBool("IsMove", isMoving);
        child.GetComponent<Animator>().SetBool("IsMove", isMoving); 
    }
}
