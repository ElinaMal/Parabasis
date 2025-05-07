using UnityEngine;

public class SoundEffects : MonoBehaviour
{
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
    private void Start()
    {
        music.clip = background;
        music.Play();
    }

    public static SoundEffects instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
