using UnityEngine;

public class Guidance : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrowBody1;
    public GameObject arrow2;
    public GameObject arrowBody2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(arrow1);
        Destroy(arrowBody1);

        arrow2.GetComponent<Renderer>().enabled = true;
        arrowBody2.GetComponent<Renderer>().enabled = true;
    }
}
