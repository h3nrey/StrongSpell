using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseController : MonoBehaviour
{
    [SerializeField] 
    private PlayerBehaviour _player;

    private Vector2 input => _player.input;
    private Rigidbody2D rb => _player.rb;

    [SerializeField]
    private GameObject defensePoint;

    [SerializeField]
    private Vector2[] defensePointPositions;
    private void Start() {
        _player.onOtherButton.AddListener(Defense);
        _player.onReleaseOtherButton.AddListener(ReleaseDefense);
    }

    private void OnDestroy() {
        _player.onOtherButton.RemoveListener(Defense);
    }

    private void Update() {
        if (input.x == 0 && input.y > 0) {
            defensePoint.transform.localPosition = defensePointPositions[0];
            defensePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (input.x == 0 && input.y < 0) {
            defensePoint.transform.localPosition = defensePointPositions[2];
            defensePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (input.x != 0 && input.y == 0) {
            defensePoint.transform.localPosition = defensePointPositions[1];
            defensePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void Defense() {
        if(_player.playerData.canWalkWhenDefending) { 
            _player.canMove = false;
        }
        rb.drag = _player.playerData.linearDragWhenBlocking;
        _player.isBlocking = true;
        defensePoint.SetActive(true);
    }

    public void ReleaseDefense() {
        rb.drag = _player.playerData.linearDrag;
        _player.canMove = true;
        _player.isBlocking = false;
        defensePoint.SetActive(false);
    }
}
