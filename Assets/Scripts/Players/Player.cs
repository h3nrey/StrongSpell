using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Entity/New Player/Basic Player")]
public class Player : Entity {
    public float speed;
    public float linearDrag;
    public int attackDamageAmount;
    public float attackRate;
    public LayerMask attackLayer;
}
