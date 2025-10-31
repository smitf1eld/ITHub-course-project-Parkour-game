using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private static int score = 0;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            score++;
            if (scoreText != null)
            {
                scoreText.text = "Очки: " + score;


            }
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            Destroy(gameObject);
        }
    }
}