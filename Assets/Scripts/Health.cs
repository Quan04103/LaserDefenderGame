using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int score;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem explosionEffect;
    [SerializeField] bool applyCameraShake;
    AudioPlayer audioPlayer;
    CameraShake cameraShake;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        Debug.Log(damageDealer);
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
            ShakeCamera();
            PlayExplosionEffect();
        }
    }

    public int GetHealth()
    {
        return health;
    }
    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        audioPlayer.PlayTakeDamageClip();
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.AddToScore(score);
            Destroy(gameObject);
        }
        else if(isPlayer)
        {
            levelManager.LoadOverGame();
            Destroy(gameObject);
        }
    }
    void PlayExplosionEffect()
    {
        if(explosionEffect != null)
        {
            ParticleSystem instance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(instance, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
