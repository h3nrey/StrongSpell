using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsController : MonoBehaviour
{
    private Animator anim => PlayerBehaviour.playerInstance.anim;
    private Vector2 input => PlayerBehaviour.playerInstance.input;
    private Vector2 lastInput => PlayerBehaviour.playerInstance.lastInput;
    private void Update() {
        if(Mathf.Abs(input.magnitude) > 0) {
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }
        anim.SetFloat("velX", input.x);
        anim.SetFloat("velY", input.y);
        anim.SetFloat("lastInputX", lastInput.x);
        anim.SetFloat("lastInputY", lastInput.y);
    }
}
