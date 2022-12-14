using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] PlayerBehaviour _player;

    private Rigidbody2D rb => _player.rb;
    private float speed => _player.playerData.speed;

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        _player.rb.velocity = speed * _player.input;
    }
}
