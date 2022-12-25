using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using NaughtyAttributes;

public class OlmBehaviour : MonoBehaviour
{

    [SerializeField]
    private EntityController _entity;

    [SerializeField]
    private Phases actualState = Phases.phase1;
    enum Phases {
        phase1,
        phase2,
        phase3
    }

    [Header("Check Closest")]
    [SerializeField]
    private Transform[] targets;
    [ReadOnly] public Transform closestTarget;
    [SerializeField]
    private float delayAfterCheckClosestTarget;

    [Header("Facing")]
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private LayerMask playerMask;
    public bool isFacingPlayer;

    [Header("Shoot")]
    public bool canShoot;
    [SerializeField]
    private GameObject olmSphere;
    [SerializeField]
    private float sphereSpeed;
    private float shootCurrentTime;
    [SerializeField]
    private float shootCooldown;

    [Header("floor Tail")]
    [SerializeField]
    private float delayToInstantiateFloorTail;
    [SerializeField]
    private GameObject floorTail;
    [SerializeField]
    private float timeAfterShoot;
    [SerializeField]
    private float tailXOffset;
    [SerializeField] private Transform tailYMax;
    [SerializeField]  private Transform tailYMin;
    private bool hasArisedTail;
    private GameObject activeTail;

    [Header("Interaction with Player")]
    [SerializeField]
    private string playerAttackTag;

    private void Start() {
        canShoot = true;
        closestTarget = targets[0];
        Coroutines.DoAfter(() => StartCoroutine(HandleFloorTail()), 0.5f, this);
    }

    private void Update() {
        CheckClosestTarget();
        FaceTarget();
        CheckShootCooldown();
    }

    private void FixedUpdate() {
        isFacingPlayer = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity, playerMask);

        if (isFacingPlayer && canShoot) {
            Shoot();
        }
    }

    // Find the closest player
    private void CheckClosestTarget() {
        for (int i = 0; i < targets.Length; i++) {
            float distance = Vector2.Distance(transform.position, targets[i].position);
            float closestDistance = Vector2.Distance(transform.position, closestTarget.position);
            if (distance < closestDistance) {
                Coroutines.DoAfter(() => closestTarget = targets[i], delayAfterCheckClosestTarget, this);
                return;
            }
        }
    }

    // Shoot
    private void Shoot() {
        canShoot = false;
        GameObject projectille = Instantiate(olmSphere, transform.position, Quaternion.identity);
        Rigidbody2D projectilleRb = projectille.GetComponent<Rigidbody2D>();
        projectilleRb.velocity = transform.up * sphereSpeed * Time.deltaTime;
        Coroutines.DoAfter(() => Destroy(projectille), 1.3f, this);
        
    }

    // Arise Tail of floor
    private void InstantiateFloorTail() {
        Vector2 targetPos = closestTarget.position;

        if(hasArisedTail == false) {
            float randomYPoint = Random.Range(-targetPos.normalized.y * tailYMin.position.y, -targetPos.normalized.y * tailYMax.position.y);
            Vector2 pos = new Vector2(targetPos.x + tailXOffset, randomYPoint);

            if(activeTail) {
                activeTail.SetActive(true);
                activeTail.transform.position = pos;
            } else {
                activeTail = Instantiate(floorTail, pos, Quaternion.identity);

            }


            hasArisedTail = true;
            Coroutines.DoAfter(() => {
                hasArisedTail = false;
                activeTail.SetActive(false);
            }, 1f, this);
        }
    }

    // Control the frequency of the arise of the tail
    private IEnumerator HandleFloorTail() {
        while(actualState == Phases.phase1) {
            yield return new WaitForSeconds(timeAfterShoot);
            InstantiateFloorTail();
            if (actualState != Phases.phase1) yield break;
        }
    }

    // Control when boss can shoot
    void CheckShootCooldown() {
        if (shootCurrentTime >= shootCooldown) // check if the cooldown time has passed
        {
            canShoot = true;
            // the player can shoot again, so reset the current time
            shootCurrentTime = 0.0f;
        }
        else {
            canShoot = false;
            // increment the current time
            shootCurrentTime += Time.deltaTime;
        }
    }

    // Face toward player
    private void FaceTarget() {
        Vector2 distance = closestTarget.position - transform.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(playerAttackTag)) {
            _entity.TakeDamage(1);
        }
    }

    private void OnDrawGizmos() {

        if (isFacingPlayer) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.up * 100f);
        } else {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.up * 100f);
        }

    }
}
