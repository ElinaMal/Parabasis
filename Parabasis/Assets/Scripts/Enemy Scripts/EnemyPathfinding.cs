using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class EnemyPathfinding : MonoBehaviour
{
    public static EnemyPathfinding instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Node> GeneratePath(Node start, Node target)
    {
        List<Node> nodesToCheck = new List<Node>();

        foreach(Node n in FindObjectsOfType<Node>())
        {
            n.G = float.MaxValue;
        }

        start.G = 0;
        start.H = Vector2.Distance(start.transform.position, target.transform.position);
        nodesToCheck.Add(start);

        while(nodesToCheck.Count > 0)
        {
            int lowestF = default;

            for (int i = 1; i < nodesToCheck.Count; i++)
            {
                if (nodesToCheck[i].F() < nodesToCheck[lowestF].F())
                {
                    lowestF = i;
                }
            }

            Node thisNode = nodesToCheck[lowestF];
            nodesToCheck.Remove(thisNode);

            if (thisNode == target)
            {
                List<Node> path = new List<Node>();

                path.Insert(0, target);

                while (thisNode != target)
                {
                    thisNode = thisNode.cameFrom;
                    path.Add(thisNode);
                }

                path.Reverse();
                return path;
            }

            foreach (Node connectedNode in thisNode.connections)
            {
                float heldG = thisNode.G + Vector2.Distance(thisNode.transform.position, connectedNode.transform.position);

                if (heldG < connectedNode.G)
                {
                    connectedNode.cameFrom = thisNode;
                    thisNode.G = heldG;
                    thisNode.H = Vector2.Distance(connectedNode.transform.position, target.transform.position);

                    if (!nodesToCheck.Contains(connectedNode))
                    {
                        nodesToCheck.Add(connectedNode);
                    }
                }
            }
        }

        return null;
    }
}
