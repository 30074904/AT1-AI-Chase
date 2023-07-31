using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [Tooltip("Parent directly above node should always be first in array.")]
    [SerializeField] private Node[] parents;
    [Tooltip("Child directly below node should always be first in array.")]
    [SerializeField] private Node[] children;
    private Vector3 checkingnode;

    public List<Vector3> neighbours = new List<Vector3>();
    /// <summary>
    /// Returns the children of the node.
    /// </summary>
    public Node[] Children { get { return children; } }
    /// <summary>
    /// Returns the parents of the node.
    /// </summary>
    public Node[] Parents { get { return parents; } }

    public bool marked = false;
    private Vector3 offset = new Vector3(0, 1, 0);

    private void start()
    {
    }

    private void OnDrawGizmos()
    {
        //Draws red lines between a parent and its children.
        if (parents.Length > 0)
        {
            foreach (Node node in parents)
            {
                Debug.DrawLine(transform.position, node.transform.position, Color.red);
            }
        }
        //Draws green lines between a child and its children.
        if (children.Length > 0)
        {
            foreach (Node node in children)
            {
                Debug.DrawLine(transform.position + offset, node.transform.position + offset, Color.green);
            }
        }
    }
    public List<Node> GetChildLocation()
    {
        foreach (Node node in children)
        {
            checkingnode = node.transform.position;
            if (!neighbours.Contains(checkingnode))
            {
                neighbours.Add(node.transform.position);
            }
            return neighbours;
        }
    }

    public Vector3 GetLocation(Vector3 nodeloc, Node node)
    {
        nodeloc = node.transform.position;
        return nodeloc;
    }
    public void GetChildren()
    {

    }
}
