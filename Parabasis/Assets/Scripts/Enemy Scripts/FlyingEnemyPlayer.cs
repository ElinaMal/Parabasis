using UnityEngine;

public class FlyingEnemyPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float detectionRange;
    [SerializeField] private string tagName;
    public FlyingEnemyPatrol enemyPatrol;
    LayerMask mask;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        LayerMask layerMask = LayerMask.GetMask("Default");
        mask = layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        Vector2 directionToPlayer = enemyToPlayer.normalized;
        float distance = enemyToPlayer.magnitude;

        Ray ray = new Ray(transform.position, player.position);

        Debug.DrawLine(ray.origin, ray.direction);

        if (Physics.Raycast(ray, out RaycastHit hit, detectionRange))
        {
            enemyPatrol.enabled = false;

            if (hit.collider.CompareTag(tagName))
            {
                enemyPatrol.enabled = false;

                _rb.linearVelocity = hit.normal;
            }
        }
        else
        {
            enemyPatrol.enabled = true;
        }
    }
}
