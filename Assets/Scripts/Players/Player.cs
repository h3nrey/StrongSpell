using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
[CreateAssetMenu(menuName = "Entity/New Player/Basic Player")]
public class Player : Entity {
    public float speed;
    public float linearDrag;
    public int attackDamageAmount;
    public float attackRate;
    public LayerMask attackLayer;
    public float attackRange;
    public float linearDragWhenBlocking;
    public bool canWalkWhenDefending;
    public float knockbackForceWhenDefenfing;

    [Header("Run")]
    public float runSpeed;
    public float runDrag;
}
