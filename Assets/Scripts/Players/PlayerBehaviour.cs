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

    [Header("Inputs Events")]
    public UnityEvent onAttack;

    [Header("Components")]
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator anim;


    private void Awake() {
        playerInstance = this;
    }


}
