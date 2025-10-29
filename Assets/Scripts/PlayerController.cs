using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public InputAction playerAction;
    public float moveSpeed = 10.0f;
    Vector2 pos;

    private void OnEnable()
    {
        playerAction.Enable();
    }

    private void Update()
    {
        var moveDirection = playerAction.ReadValue<Vector2>();
        pos += moveDirection * moveSpeed * Time.deltaTime;
    }
}
