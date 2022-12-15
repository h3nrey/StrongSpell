using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : MonoBehaviour
{
    PlayerBehaviour _player => PlayerBehaviour.playerInstance;

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 0.01f);
    }
}
