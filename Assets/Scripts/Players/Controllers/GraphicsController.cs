using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsController : MonoBehaviour {
    PlayerBehaviour _player => PlayerBehaviour.playerInstance;
    private Animator anim => PlayerBehaviour.playerInstance.anim;
    private Vector2 input => PlayerBehaviour.playerInstance.input;
    private Vector2 lastInput => PlayerBehaviour.playerInstance.lastInput;

    [SerializeField]
    private bool isStrongPlayer;

    private void Start() {
        _player.onAttack.AddListener(PlayAttackAnimation);
    }
    private void OnDestroy() {
        _player.onAttack.RemoveListener(PlayAttackAnimation);
    }

    private void Update() {
        if (Mathf.Abs(input.magnitude) > 0) {
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }
        SettingUpDirection();
        

        //attack
        anim.SetBool("canAttack", _player.canAttack);

        //block
        anim.SetBool("isBlocking", _player.isBlocking);
    }

    private void PlayAttackAnimation() {
        if(_player.canAttack)
            anim.SetTrigger("attack");
    }

    private void SettingUpDirection() {
        if(isStrongPlayer) {
            anim.SetFloat("velX", input.x);
            anim.SetFloat("velY", input.y);
            anim.SetFloat("lastInputX", lastInput.x);
            anim.SetFloat("lastInputY", lastInput.y);
        } else {
            anim.SetFloat("velX", _player.lookDir.x);
            anim.SetFloat("velY", _player.lookDir.y);
            anim.SetFloat("lastInputX", _player.lookDir.x);
            anim.SetFloat("lastInputY", _player.lookDir.y);
        }
    }
}
