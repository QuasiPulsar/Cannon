using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab
    public Transform projectileSpawnPoint; // Assign the spawn point
    public float launchAcceleration = 10f; // Acceleration
    public float initialVelocity = 5f; // Initial velocity

    void Update()
    {
        // Check for input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Instantiate the projectile at the spawn point
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);

        // Get the Rigidbody component
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            //launch force
            float time = 1f; // trajectory
            Vector3 launchForce = (0.5f * launchAcceleration * time * time + initialVelocity * time) * projectileSpawnPoint.forward;
            //0.5 is technically 1/2

            // Applying force
            rb.AddForce(launchForce, ForceMode.Impulse);
        }
    }
}

