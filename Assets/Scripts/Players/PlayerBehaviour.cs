using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    [Expandable] public Player playerData;

    public Vector2 input;

    [Header("Components")]
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Rigidbody2D rb;



}
