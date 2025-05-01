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

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectsSourse.PlayOneShot(clip);
    }
}
