using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller=GetComponent<TopDownCharacterController>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnLookEvent += OnAim; 
    }

    private void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection); 
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
