using UnityEngine;

public class FlyingEnemyPlayer : MonoBehaviour
{
    public Transform player;
    public Transform initialPosition;
    [SerializeField] private float detectionRange;
    public FlyingEnemyPatrol enemyPatrol;
    LayerMask mask;
    RaycastHit2D hit;
    private Rigidbody2D _rb;
    [SerializeField] private string objectName;
    [SerializeField] private float velocity;
    [SerializeField] private float setLimit;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        LayerMask layerMask = LayerMask.GetMask("Platform", "Player", "Floor");
        mask = layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tracker = transform.position - initialPosition.position;
        float limit = tracker.magnitude;

        Vector2 enemyToPlayer = player.position - transform.position;
        Vector2 directionToPlayer = enemyToPlayer.normalized;
        float distance = enemyToPlayer.magnitude;

        hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, mask);

        if (Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, mask))
        {
            if ((hit.collider.gameObject.name == objectName) && (distance < detectionRange) && (limit < setLimit))
            {
                enemyPatrol.enabled = false;

                transform.position = Vector2.MoveTowards(transform.position, player.position, velocity * Time.deltaTime);

                if (directionToPlayer.x > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, -180, 0);
                }
            }
            else
            {
                enemyPatrol.enabled = true;
            }
        }
    }
}
