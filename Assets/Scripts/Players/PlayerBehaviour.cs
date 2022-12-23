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

    [SerializeField]
    public bool isStrongPlayer;

    public Vector2 input;
    public Vector2 lastInput;
    public Vector2 mousePos;
    public Vector2 lookDir;

    [Header("Inputs Events")]
    public UnityEvent onAttack;
    public UnityEvent onOtherButton;
    public UnityEvent onReleaseOtherButton;

    [Header("Movement")]
    [ReadOnly] public bool canMove;
    [ReadOnly] public Vector2 vel;

    [Header("Attack")]
     public bool canAttack;
    [SerializeField]
    public Transform attackPoint;

    [Header("Defense")]
    [ReadOnly] public bool isBlocking;


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
