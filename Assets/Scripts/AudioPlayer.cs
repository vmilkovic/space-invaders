using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

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
            DontDestroyOnLoad(instance);
        }
    }

    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            PlayClip(shootingClip, shootingVolume);
        }
    }

    public void SetShootingClipVolume(float volume)
    {
        shootingVolume = volume;
    }

    public float GetShootingClipVolume()
    {
        return shootingVolume;
    }

    public void PlayDamageClip()
    {
        if(damageClip != null)
        {
            PlayClip(damageClip, damageVolume);
        }
    }

    public void SetDamageClipVolume(float volume)
    {
        damageVolume = volume;
    }

    public float GetDamageClipVolume()
    {
        return damageVolume;
    } 

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
        }
    }
}
