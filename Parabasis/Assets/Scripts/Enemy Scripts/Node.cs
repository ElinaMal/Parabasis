using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public Node cameFrom;
    public List<Node> connections;
    public Transform player;
    public bool target;

    public float G;
    public float H;

    public float F()
    {
        return G + H;
    }

    public void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        float distance = enemyToPlayer.magnitude;

        if (distance < 1)
        {
            target = true;
        }
        else
        {
            target = false;
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (connections.Count > 0)
        {
            for (int i = 0; i < connections.Count; i++)
            {
                Gizmos.DrawLine(transform.position, connections[i].transform.position);
            }
        }
    }
    */
}
