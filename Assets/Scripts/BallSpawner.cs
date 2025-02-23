using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Vector3 spawnPosition;

    private GameObject currentBall;
    [SerializeField] float gravity = -10f;
    [SerializeField] float tableAngle = 7f;

    void Start()
    {
        SpawnBall();
    }

    void Update() {
        if (currentBall.transform.position.z < -8) {
            DestroyBall();
        }
    }

    void SpawnBall()
    {
        UnityEngine.Debug.Log("Spawning ball");
        // Instantiate a new ball from the ballPrefab
        GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        Ball ballScript = newBall.GetComponent<Ball>();
        ballScript.gravity = gravity;
        ballScript.tableAngle = tableAngle;
        ballScript.table = Camera.main.transform;
        newBall.tag = "Ball";

        // Disable gravity and enable kinematic on the ball's Rigidbody component
        // Note: We should not be using Unity's Rigidbody at all
        //Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();
        //ballRigidbody.useGravity = false;
        //ballRigidbody.isKinematic = true;


        // Set the current ball to the newly spawned ball
        currentBall = newBall;
    }

    void DestroyBall() {
        Health.Instance.health--;
        Destroy(currentBall);
        currentBall = null;

        StartCoroutine(Respawn());
    }

    IEnumerator Respawn() {
        yield return new WaitForSeconds(1);

        // Check if there are any balls in the game
        if (Health.Instance.health > 0) { // GameObject.FindGameObjectsWithTag("Ball").Length == 0 && 
            SpawnBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("OnCollisionEnter called");
        if (collision.gameObject.CompareTag("Ball"))
        {
            Health.Instance.health--;
            UnityEngine.Debug.Log("Destroying ball");
            Destroy(collision.gameObject);
            currentBall = null;

            StartCoroutine(Respawn());
        }
    }
}

