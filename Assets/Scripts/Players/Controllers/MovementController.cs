using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] PlayerBehaviour _player;

    private Rigidbody2D rb => _player.rb;
    private Vector2 input => PlayerBehaviour.playerInstance.input;
    private Vector2 lastInput => PlayerBehaviour.playerInstance.lastInput;
    private float speed => _player.playerData.speed;


    private void FixedUpdate() {
        Move();
    }

    private void Update() {
        SettingFacing();
    }

    private void Move() {
        if(_player.canMove) {
            _player.rb.AddForce(speed * input * Time.fixedDeltaTime);
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
