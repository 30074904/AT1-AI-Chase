using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [Tooltip("Parent directly above node should always be first in array.")]
    [SerializeField] private Node[] parents;
    [Tooltip("Child directly below node should always be first in array.")]
    [SerializeField] private Node[] children;

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

    private Vector3 checkingnode = new Vector3(0, 0, 0);

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
    public List<Vector3> GetChildLocation(List<Vector3> neighbours, GameObject currnode)
    {
        foreach (Node node in currnode.children)
        {
            // I need to check if the bool marked is true or false if its false then change it to true on the node and go there.
            //GetChecked = node.TryGetComponent<Node>();
            if (node.marked == false)
            {
                checkingnode = node.transform.position;
                neighbours.Add(checkingnode);
                marked = true;
                return neighbours;
            }
            else
            {
                return null;
            }
        }
        return null;
    }
    /*public void GetNodeComponent()
    {
        foreach (Node node in children)
        {
            // I need to check if the bool marked is true or false if its false then change it to true on the node and go there.
            GetChecked = node.TryGetComponent<Node>();
            return 
        }
    }*/
    public Vector3 GetLocation(Vector3 nodeloc, Node node)
    {
        nodeloc = node.transform.position;
        return nodeloc;
    }
    public int GetChildren(int itemp, int btemp)
    {
        itemp = itemp + 1;
        btemp = itemp;
        return btemp;
    }
}
