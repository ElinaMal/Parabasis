using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public Node thisNode;
    public List<Node> path = new List<Node>();
    public Node chase;

    // Update is called once per frame
    void Update()
    {
        CreatePath();
    }

    public void CreatePath()
    {
        if (path.Count > 0)
        {
            int x = 0;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(path[x].transform.position.x, path[x].transform.position.y), 3 * Time.deltaTime);

            if (Vector2.Distance(transform.position, path[x].transform.position) < 0.1f)
            {
                thisNode = path[x];
                path.RemoveAt(x);
            }
        }
        else
        {
            FindTarget();

            while (path == null || path.Count == 0)
            {
                path = EnemyPathfinding.instance.GeneratePath(thisNode, chase);
            }
        }
    }

    public void FindTarget()
    {
        Node[] nodes = FindObjectsOfType<Node>();


        while (nodes.Length > 0)
        {
            Node node = nodes[0];

            if (node.target == false)
            {
                //nodes.Remove(node);
            }
            else
            {
                chase = node;
                break;
            }
        }
    }
}
