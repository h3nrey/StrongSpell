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
    }
}
