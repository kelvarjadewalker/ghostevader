using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Editor Fields
    [Header("Background Music")] 
    [SerializeField] private AudioSource gameMusicSource;
    [Range(0, 1)] [SerializeField] private float gameMusicVolume = 0.5f;
    
    [Header("Sound Effects")]
    [SerializeField] private AudioSource sfxSoundSource;
    [SerializeField] private AudioClip pickupSound;
    [SerializeField] private AudioClip playerDeathSound;
    [Range(0, 1)][SerializeField] private float soundEffectVolume = 0.5f;
    
    // Unity Events
    private void Start()
    {
        gameMusicSource.volume = gameMusicVolume;
        gameMusicSource.loop = true;
        gameMusicSource.Play();


        sfxSoundSource.volume = soundEffectVolume;
        sfxSoundSource.loop = false;
    }
    
    // External Functions
    public void PlayerPickupSound()
    {
        sfxSoundSource.PlayOneShot(pickupSound, soundEffectVolume);
    }

    public void PlayerDeathSound()
    {
        sfxSoundSource.PlayOneShot(playerDeathSound, soundEffectVolume);
    }

}
