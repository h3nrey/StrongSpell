using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class MageAttackController : MonoBehaviour
{
    [SerializeField]
    PlayerBehaviour _player;

    [SerializeField]
    private MagePlayer mageData;

    [SerializeField]
    private Transform shootPoint;

    private Vector2 mousePos => _player.mousePos.normalized;
    private Vector2 lookdir => _player.lookDir;
    private bool canAttack {
        get => _player.canAttack;
        set => _player.canAttack = value;
    }


    private void Start() {
        _player.onAttack.AddListener(HandleAttack);
    }

    private void OnDestroy() {
        _player.onAttack.RemoveListener(HandleAttack);
    }

    private void Update() {
        //print($"can attack: {_player.canAttack}");
    }

    private void Shoot() {
        Vector2 direction = lookdir.normalized;
        GameObject energy = Instantiate(mageData.energyPrefab, shootPoint.position, Quaternion.identity) as GameObject;
        Rigidbody2D energyRb = energy.GetComponent<Rigidbody2D>();
        energyRb.velocity += direction * mageData.energySpeed;
        Coroutines.DoAfter(() => Destroy(energy), mageData.energyTimeToDestroy, this);
    }

    private void HandleAttack() {
        if(_player.canAttack) {
            print("Atacando magia");
            canAttack = false;
            Shoot();
        }
    }
}
