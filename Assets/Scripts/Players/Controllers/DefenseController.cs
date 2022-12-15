using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseController : MonoBehaviour
{
    [SerializeField] 
    private PlayerBehaviour _player;

    [SerializeField]
    private StrongPlayer strongPlayerData;

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
        if (_player.input.x == 0 && _player.input.y > 0) {
            defensePoint.transform.localPosition = defensePointPositions[0];
            defensePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (_player.input.x == 0 && _player.input.y < 0) {
            defensePoint.transform.localPosition = defensePointPositions[2];
            defensePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (_player.input.x != 0 && _player.input.y == 0) {
            defensePoint.transform.localPosition = defensePointPositions[1];
            defensePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void Defense() {
        if(strongPlayerData.canWalkWhenDefending) { 
            _player.canMove = false;
        }
        _player.isBlocking = true;
        defensePoint.SetActive(true);
    }

    public void ReleaseDefense() {
        _player.canMove = true;
        _player.isBlocking = false;
        defensePoint.SetActive(false);
    }
}
