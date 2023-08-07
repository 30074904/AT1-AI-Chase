using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstAlgo : MonoBehaviour
{
    public GameObject RootNode;
    public Node nodescript;
    public int i = 1;
    public int b = 3;
    private List<Vector3> children;
    private Node nodestat;
    public new Vector3 nodechecked;
    public void start()
    {
        //nodes = RootNode.GetComponent<Node>();
        nodescript = RootNode.GetComponent<Node>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayAlgo();
    }

    // Update is called once per frame
    void Update()
    {
        //i = nodescript.GetChildren(i, b);
        //Debug.Log(nodescript.GetChildren(i, b));
        children
    }
    public void PlayAlgo()
    {

        children = nodescript.GetChildLocation(children);
        //nodestat = nodescript.GetChildLocation(children, nodestat);
        //nodechecked = nodescript.GetChildLocation(children, nodechecked);
        foreach (Vector3 node in children)
        {
            Debug.Log("hi");
        }

    }
}
