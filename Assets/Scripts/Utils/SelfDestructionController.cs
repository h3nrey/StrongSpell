using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructionController : MonoBehaviour
{
    public void DestroySelf() {
        Destroy(this.gameObject);
    }
}
