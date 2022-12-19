using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongPlayerAttackController : MonoBehaviour
{
    PlayerBehaviour _player => PlayerBehaviour.playerInstance;
    Vector2 input => _player.input;
    [SerializeField]
    StrongPlayer strongPlayerData;
    float attackRange => strongPlayerData.attackRange;
    [SerializeField]
    private Transform attackPoint;

    LayerMask attackLayer => _player.playerData.attackLayer;

    private bool canAttack {
        get => _player.canAttack;
        set => _player.canAttack = value;
    }

    [SerializeField]
    private Vector2[] attackPoints;
    private void Start() {
        _player.onAttack.AddListener(Attack);
    }

    private void OnDestroy() {
        _player.onAttack.RemoveListener(Attack);
    }

    private void Attack() {
        print("Start Attack");
        Collider2D[] attackedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayer);


        if (canAttack) {
            foreach (Collider2D enemy in attackedEnemies) {
                enemy.gameObject.GetComponent<EntityController>().TakeDamage(_player.playerData.attackDamageAmount);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
