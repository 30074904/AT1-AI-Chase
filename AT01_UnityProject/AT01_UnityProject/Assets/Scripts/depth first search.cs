using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstSearch : MonoBehaviour
{
    public GameObject RootNode;
    public Node nodescript;
    public int i = 1;
    public void start()
    {
        //nodes = RootNode.GetComponent<Node>();
        nodescript = RootNode.GetComponent<Node>();
        //nodescript.GetChildren(i);
        //Debug.Log(i);
    }
}
