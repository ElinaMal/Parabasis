using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public VolumeSetting volumeSetting;

    [SerializeField] AudioSource soundEffectsSourse;
    [SerializeField] AudioSource music;

    public AudioClip jumpSound;
    public AudioClip walkingSound;
    public AudioClip attackSound;
    public AudioClip dashingSound;
    public AudioClip damageSound;
    public AudioClip blockSound;
    public AudioClip stunSound;
    public AudioClip landingSound;
    public AudioClip background;

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectsSourse.PlayOneShot(clip);
    }
}
