using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 5f;
    private float moveDirection;
    private PongInput inputActions;


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
        Vector3 movement = new Vector3(0, moveDirection, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
