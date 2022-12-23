using UnityEngine;
using Utils;

public class AttackController : MonoBehaviour {
    PlayerBehaviour _player => PlayerBehaviour.playerInstance;
    Vector2 input => _player.input;

    Transform attackPoint => _player.attackPoint;

    private bool canAttack {
        get => _player.canAttack;
        set => _player.canAttack = value;
    }

    [SerializeField]
    private Vector2[] attackPoints;
    private void Start() {
        _player.onAttack.AddListener(HandleAttack);
    }

    private void OnDestroy() {
        _player.onAttack.RemoveListener(HandleAttack);
    }

    private void Update() {
        if(input.x == 0 && input.y < 0) {
            attackPoint.localPosition = attackPoints[0];
        } else if (input.x > 0 && input.y == 0) {
            attackPoint.localPosition = attackPoints[1];
        } else if (input.x == 0 && input.y > 0) {
            attackPoint.localPosition = attackPoints[2];
        } else if (input.x < 0 && input.y == 0) {
            attackPoint.localPosition = attackPoints[3];
        }
    }

    private void HandleAttack() {
        if(canAttack == true) {
            Coroutines.DoAfter(() => canAttack = true, _player.playerData.attackRate, this);
        }
        //Coroutines.DoAfter(() => {
        //    _player.canAttack = false;
        //    print("Finish Attack");
        //}, 0.05f, this);
    }

}
