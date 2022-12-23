using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class OlmBehaviour : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Transform target;

    public bool isFacingPlayer;
    public bool canShoot;
    [SerializeField]
    private GameObject olmSphere;
    [SerializeField]
    private float sphereSpeed;
    [SerializeField]
    private LayerMask playerMask;
    private float shootCurrentTime;
    [SerializeField]
    private float shootCooldown;

    private void Update() {
        FaceTarget();
        CheckShootCooldown();
    }

    private void Start() {
        canShoot = true;
    }

    private void FixedUpdate() {
        isFacingPlayer = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity, playerMask);

        if (isFacingPlayer && canShoot) {
            Shoot();
        }
    }

    private void Shoot() {
        canShoot = false;
        GameObject projectille = Instantiate(olmSphere, transform.position, Quaternion.identity);
        Rigidbody2D projectilleRb = projectille.GetComponent<Rigidbody2D>();
        projectilleRb.velocity = transform.up * sphereSpeed * Time.deltaTime;
        
    }

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

    private void FaceTarget() {
        Vector2 distance = target.position - transform.position;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
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
