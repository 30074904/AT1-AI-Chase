using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstAlgo : MonoBehaviour
{
    [SerializeField] public Node RootNode;
    public Node nodescript;
    public Node destination;
    public int i = 1;
    public int b = 3;
    private List<Vector3> children;
    private List<Node> visited;
    private Node nodestat;
    public new Vector3 nodechecked;

    private bool found = false;
    public void start()
    {
        //nodes = RootNode.GetComponent<Node>();
        //nodescript = RootNode.GetComponent<Node>();
        
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
        //children
    }
    public void PlayAlgo()
    {

        //children = nodescript.GetChildLocation(children);
        //nodestat = nodescript.GetChildLocation(children, nodestat);
        //nodechecked = nodescript.GetChildLocation(children, nodechecked);
        foreach (Vector3 node in children)
        {
            Debug.Log("hi");
        }

    }
    // start search algorith
    public void searchalgo(Node Root)
    {
        
        // checking the root node for children and making children root node while the destination is not found.
        while (found == false)
        {
            visited.Add(Root);
            if (Root == destination)
            {
                found = true;
            }
            for (i = 0; i < Root.children.Count; i++)
            {
                for (y = 0; y < visited; y++)
                {
                    if (Root.children[i] != visited[y])
                    {
                        Root.children[i] = Root;

                        break;
                    }
                }
                break;
                
            }
        }
        
    }
}
