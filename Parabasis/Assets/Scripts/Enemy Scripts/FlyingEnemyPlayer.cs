using UnityEngine;

public class FlyingEnemyPlayer : MonoBehaviour
{
    public Transform player;
    [SerializeField] private float detectionRange;
    [SerializeField] private string tagName;
    public EnemyPatrol enemyPatrol;
    LayerMask layerMask = LayerMask.GetMask();
    [SerializeField] private float castRadius;
    [SerializeField] private float circlaCastDistance;

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        Vector2 directionToPlayer = enemyToPlayer.normalized;
        float distance = enemyToPlayer.magnitude;

        Ray ray = new Ray(transform.position, directionToPlayer);

        if (Physics.Raycast(ray, out RaycastHit hit, detectionRange, layerMask))
        {

        }

        if (Physics2D.CircleCast(transform.position, castRadius, transform.forward, circlaCastDistance))
        {

        }
    }
}
