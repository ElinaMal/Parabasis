using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] AudioSource soundEffectsSourse;

    public AudioClip jumpSound;
    public AudioClip walkingSound;
    public AudioClip attackSound;
    public AudioClip dashingSound;
    public AudioClip damageSound;
    public AudioClip blockSound;
    public AudioClip stunSound;
    public AudioClip landingSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectsSourse.PlayOneShot(clip);
    }
}
