using UnityEngine;

public class AttackController : MonoBehaviour {
    PlayerBehaviour _player => PlayerBehaviour.playerInstance;
    Vector2 input => _player.input;
    [SerializeField]
    StrongPlayer strongPlayerData;
    float attackRange => strongPlayerData.attackRange;
    [SerializeField]
    private Transform attackPoint;

    LayerMask attackLayer => _player.playerData.attackLayer;


    [SerializeField]
    private Vector2[] attackPoints;
    private void Start() {
        _player.onAttack.AddListener(Attack);
    }

    private void OnDestroy() {
        _player.onAttack.RemoveListener(Attack);
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

    private void Attack() {
        Collider2D[] attackedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayer);

        foreach(Collider2D enemy in attackedEnemies) {
            print(enemy.gameObject.name);
            //take damage of Enemy
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
