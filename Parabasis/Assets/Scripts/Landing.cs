using UnityEngine;

public class Landing : MonoBehaviour
{
    public SoundEffects audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffects>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            audioManager.PlaySoundEffect(audioManager.landingSound);
        }
    }
}
