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
        }

        return null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
