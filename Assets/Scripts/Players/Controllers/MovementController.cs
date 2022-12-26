using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class MovementController : MonoBehaviour
{
    [SerializeField] PlayerBehaviour _player;

    private Rigidbody2D rb => _player.rb;
    private Vector2 input => PlayerBehaviour.playerInstance.input;
    private Vector2 lastInput => PlayerBehaviour.playerInstance.lastInput;
    private float speed => _player.playerData.speed;
    private bool isStrongPlayer => _player.isStrongPlayer;

    private float runSpeed => _player.playerData.runSpeed;
    private float runMultiplier = 1f;
    private Vector2 vel {
        get => _player.vel;
        set => _player.vel = value;
    }


    private void FixedUpdate() {
        Move();
        Run();
        vel = _player.rb.velocity;
    }

    private void Update() {
        SettingFacing();
    }

    private void Move() {
        if(_player.canMove) {
            _player.rb.AddForce(speed * runMultiplier * input * Time.fixedDeltaTime);
        }
    }

    private void Run() {
        if(_player.holdingRunButton) {
            print("Holding Button");
            runMultiplier = runSpeed;
            _player.rb.drag = _player.playerData.runDrag;
        } else {
            runMultiplier = 1;

            Coroutines.DoAfter(() => _player.rb.drag = _player.playerData.linearDrag, 0.6f, this);
        }
    }

    private void SettingFacing() {
        Vector3 scale = _player.transform.localScale;
        if(input.x > 0) {
            _player.transform.localScale = new Vector3(1,1,1);
        } else if (input.x < 0) {
            _player.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
