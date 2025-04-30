using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthUI : MonoBehaviour
{
    public Health health;

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;

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
        }
        else if (health.health == 4)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            health5.SetActive(false);
        }
        else if (health.health == 3)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(false);
            health5.SetActive(false);
        }
        else if (health.health == 2)
        {
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);
        }
        else if (health.health == 1)
        {
            health1.SetActive(true);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);
        }
        else
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            health5.SetActive(false);

            SceneManager.LoadSceneAsync(4);
        }
    }
}
