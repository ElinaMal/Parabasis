using UnityEngine;

public class CameraFunctions : MonoBehaviour
{
    [SerializeField] private float damping;
    [SerializeField] private Vector3 offset;
    public GameObject preFab;
    public Transform target;
    private Vector3 vel = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref
        vel, damping);

        Transform child = gameObject.transform.GetChild(0);

        if (child.position.x < transform.position.x - 21)
        {
            Instantiate(preFab, new Vector3(child.position.x + 42, child.position.y, 0), Quaternion.identity, transform);
            Destroy(child.gameObject);
        }
    }
}
