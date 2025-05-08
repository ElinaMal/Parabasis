using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject glow;
    public Button mask;

    // Update is called once per frame
    void Update()
    {
        glow.transform.position = mask.transform.position;
    }
}
