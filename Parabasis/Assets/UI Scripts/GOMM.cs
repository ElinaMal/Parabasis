using UnityEngine;
using UnityEngine.SceneManagement;

public class GOMM : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}