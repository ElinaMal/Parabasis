using UnityEngine;

public class GuidanceMask : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrow2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(arrow1);
        arrow2.GetComponent<Renderer>().enabled = true;
    }
}
