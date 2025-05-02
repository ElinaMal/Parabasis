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
        LayerMask layerMask = LayerMask.GetMask("Floor");

        if (Physics2D.Raycast(transform.position, Vector2.down, 1.5f, layerMask))
        {
            audioManager.PlaySoundEffect(audioManager.landingSound);
        }
    }
}
