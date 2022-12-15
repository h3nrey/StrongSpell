using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] PlayerBehaviour playerContainer;
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
}
