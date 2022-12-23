using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionController : MonoBehaviour
{
    [SerializeField]
    EntityController _entity;
    [SerializeField]
    PlayerBehaviour _player;
    UnityEvent onTouchEnemy;

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject otherObj = other.gameObject;
        Vector2 otherNormal = other.GetContact(0).normal;
        string otherTag = otherObj.tag;

        if(otherTag == "Enemy") {
            if(!_player.isBlocking) {
                _entity.ExecuteKnockback(otherNormal, _entity._entitty.knockbackForce);
                _entity.TakeDamage(1);
            } else {
                _entity.ExecuteKnockback(otherNormal, _entity._entitty.knockbackForce / 2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        Vector2 otherNormal = other.attachedRigidbody.velocity.normalized;
        string otherTag = otherObj.tag;

        if (otherTag == "Enemy") {
            if (!_player.isBlocking) {
                _entity.ExecuteKnockback(otherNormal, _entity._entitty.knockbackForce);
                _entity.TakeDamage(1);
            }
            else {
                _entity.ExecuteKnockback(otherNormal, _entity._entitty.knockbackForce / 2);
            }
        }
    }
}
