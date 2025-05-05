using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour
{
    public Health health;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;

    public Volume volume;
    public Vignette vg;
    public GameObject postPros;

    private void Start()
    {
        postPros = GameObject.Find("PostProcessing");
        volume = postPros.GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.health == 5)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(true);

            if (volume.profile.TryGet(out vg))
            {
                vg.intensity.Override(0);
            }
        }
        else if (health.health == 4)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(false);

            if (volume.profile.TryGet(out vg))
            {
                vg.intensity.Override(0.4f);
            }
        }
        else if (health.health == 3)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(false);
            health5.SetActive(false);

            if (volume.profile.TryGet(out vg))
            {
                vg.intensity.Override(0.5f);
            }
        }
        else if (health.health == 2)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);

            if (volume.profile.TryGet(out vg))
            {
                vg.intensity.Override(0.55f);
            }
        }
        else if (health.health == 1)
        {
            health1.SetActive(true);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);

            if (volume.profile.TryGet(out vg))
            {
                vg.intensity.Override(0.6f);
            }
        }
        else
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);

            if (volume.profile.TryGet(out vg))
            {
                vg.intensity.Override(0);
            }

            SceneManager.LoadSceneAsync(4);
        }
    }
}
