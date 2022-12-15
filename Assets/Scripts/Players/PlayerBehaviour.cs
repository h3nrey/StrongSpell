using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    [Expandable] public Player playerData;

    public static PlayerBehaviour playerInstance;

    public Vector2 input;
    public Vector2 lastInput;

    [Header("Movement")]
    [ReadOnly] public bool canMove;

    [Header("Attack")]
    [ReadOnly] public bool canAttack;

    [Header("Defense")]
    [ReadOnly] public bool isBlocking;

    [Header("Inputs Events")]
    public UnityEvent onAttack;
    public UnityEvent onOtherButton;
    public UnityEvent onReleaseOtherButton;

    [Header("Components")]
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator anim;


    private void Awake() {
        playerInstance = this;
    }

    private void Start() {
        InitializePlayer();        
    }

    private void InitializePlayer() {
        canAttack = true;
        canMove = true;
    }
}
