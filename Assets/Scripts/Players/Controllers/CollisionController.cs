using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionController : MonoBehaviour
{
    UnityEvent onTouchEnemy;

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject otherObj = other.gameObject;
        string otherTag = otherObj.tag;

        if(otherTag == "Enemy") {
            GetComponent<EntityController>().TakeDamage(1);
            print("tested");
        }
    }
}
