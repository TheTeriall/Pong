using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5f;
    private float moveDirection;
    private PongInput inputActions;
    private float minY = -3f;
    private float maxY = 3f;


    private void Awake()
    {
        inputActions = new PongInput();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.MoveUp.performed += OnMoveUp;
        inputActions.Player.MoveUp.canceled += OnMoveUpReleased;
        inputActions.Player.MoveDown.performed += OnMoveDown;
        inputActions.Player.MoveDown.canceled += OnMoveDownReleased;
    }

    private void OnMoveDownReleased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveDirection = 0f;
    }

    private void OnMoveUpReleased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveDirection = 0f;
    }

    private void OnMoveDown(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveDirection = -1f;
    }

    private void OnMoveUp(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveDirection = 1f;
    }

    private void Update()
    {
        Vector2 movement = new Vector2(0, moveDirection) * speed * Time.deltaTime;
        transform.Translate(movement);
        Vector2 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }

    
}
