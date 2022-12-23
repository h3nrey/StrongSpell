using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using NaughtyAttributes;

public class DodgeController : MonoBehaviour
{
    [SerializeField]
    private PlayerBehaviour _player;

    [SerializeField]
    private MagePlayer _mageData;

    private Vector2 lookDir => _player.lookDir;
    [ReadOnly] public bool dodging;
    private bool canMove {
        get => _player.canMove;
        set => _player.canMove = value;
    }

    private void Start() {
        _player.onOtherButton.AddListener(Dodge);
    }

    private void OnDestroy() {
        _player.onOtherButton.RemoveListener(Dodge);
    }

    private void Update() {
        if(dodging && Mathf.Abs(_player.rb.velocity.magnitude) < 1f) {
            canMove = true;
            dodging = false;
        }
    }

    private void Dodge() {
        if(!dodging) {
            //_player.rb.velocity = Vector2.zero;
            _player.rb.AddForce(_player.input.normalized * _mageData.dodgeForce * Time.deltaTime, ForceMode2D.Impulse);
            dodging = true;
            canMove = false;
        }
    }
}
