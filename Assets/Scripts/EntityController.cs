using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class EntityController : MonoBehaviour
{
    [SerializeField]
    private Entity _entitty;

    [SerializeField] 
    private int actualLife;

    public UnityEvent onDie;
    private void Start() {
        actualLife = _entitty.life;
    }

    public void TakeDamage(int damage) {
        actualLife -= damage;
        print(actualLife);

        if(actualLife == 0) {
            onDie?.Invoke();
        }
    }
}
