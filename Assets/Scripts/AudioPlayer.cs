using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("TakeDamage")]
    [SerializeField] AudioClip takeDamageSound;
    [SerializeField] [Range(0f, 1f)] float takeDamageVolume = 1f;

    [Header("Shooting")]
    [SerializeField] AudioClip shootingSound;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
    static AudioPlayer instance;
    void Awake()
    {
        ManageSingleton();
    }
    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayAudio(shootingSound, shootingVolume);
    }
    public void PlayTakeDamageClip()
    {
        PlayAudio(takeDamageSound, takeDamageVolume);
    }
    public void PlayAudio(AudioClip sound, float volume)
    {
        if(sound != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(sound, cameraPosition, volume);
        }
    }
}
