using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerBehaviour playerContainer;

    private Vector2 mousePos {
        get => playerContainer.mousePos;
        set => playerContainer.mousePos = value;
    }

    private Vector2 lookDir {
        get => playerContainer.lookDir;
        set => playerContainer.lookDir = value;
    }

    private void Update() {
        GetMousePos();
        SettingLookDir();
    }

    public void GetMovementValues(InputAction.CallbackContext context) {
        playerContainer.input = context.ReadValue<Vector2>();
        playerContainer.input.Normalize();
        if(Mathf.Abs(playerContainer.input.magnitude) > 0) {
            playerContainer.lastInput = playerContainer.input;
        }
    }

    public void DetectAttackButton(InputAction.CallbackContext context) {
        if(context.started) {
            playerContainer.onAttack?.Invoke();
        }
    }

    public void DetectOtherButton(InputAction.CallbackContext context) {
        if(context.started) {
            playerContainer.onOtherButton?.Invoke();
        }

        if(context.canceled) {
            playerContainer.onReleaseOtherButton?.Invoke();
        }
    }

    public void GetMousePos() {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void SettingLookDir() {
        lookDir = mousePos - (Vector2)transform.position;
        lookDir.Normalize();
    }
}
