using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Entity/New Player/Strong Player")]
public class StrongPlayer : Player {
    public float attackRange;
    public float speedWhenDefending;
    public bool canWalkWhenDefending;
}
