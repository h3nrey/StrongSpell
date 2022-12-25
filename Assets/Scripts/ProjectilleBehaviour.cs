using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleBehaviour : MonoBehaviour {
    [SerializeField]
    private string tagThatWillIgnore;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != tagThatWillIgnore) {
            Destroy(this.gameObject);
        }
    }
}
