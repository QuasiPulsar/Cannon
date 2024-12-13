using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogger : MonoBehaviour
{
    private Vector3 initialPosition; // Store the initial position
    private bool hasLoggedDistance = false; // To ensure the distance is logged only once

    void Start()
    {
        // Save the initial position when the projectile is instantiated
        initialPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Log the distance only when the projectile hits the ground
        if (!hasLoggedDistance && collision.gameObject.CompareTag("Ground"))
        {
            hasLoggedDistance = true;

            // Calculate the distance
            float distanceTraveled = Vector3.Distance(initialPosition, transform.position);

            // Log the distance to the console
            Debug.Log("Projectile traveled distance: " + distanceTraveled + " units");

            // Optional: Destroy the projectile after logging
            Destroy(gameObject);
        }
    }
}
