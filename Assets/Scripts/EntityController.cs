using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class EntityController : MonoBehaviour
{
    [Expandable]
    public Entity _entitty;

    [SerializeField] 
    private int actualLife;

    [Header("Blink Effect")]
    [SerializeField]
    private Color[] blinkColors;
    [SerializeField]
    private int blinkTime;
    [SerializeField]
    private SpriteRenderer[] sprites;

    public UnityEvent onDie;
    private void Start() {
        actualLife = _entitty.life;
    }

    public void TakeDamage(int damage) {
        actualLife -= damage;
        StartCoroutine(BlinkEffect(blinkColors, blinkTime));
        print(actualLife);

        if(actualLife == 0) {
            onDie?.Invoke();
        }
    }

    public void ExecuteKnockback(Vector2 dir, float force) {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.AddForce(dir * force * Time.deltaTime);
    }

    IEnumerator BlinkEffect(Color[] colors, int blinkTime = 6) {
        for (int i = 0; i < blinkTime; i++) {
            foreach (Color color in colors) {
                foreach(SpriteRenderer sprite in sprites) {
                    sprite.color = color;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }

        
        foreach (SpriteRenderer sprite in sprites) {
            sprite.color = Color.white;
        }
    }
}
