using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Node : MonoBehaviour
{
    private Node currentNode;

    private Vector3 currentDir;
    public List<Node> nodeList = new List<Node>();
    // Start is called before the first frame update
    public delegate void ClearParentDeligate();
    public event ClearParentDeligate ClearParentEvent;

    //public static depth first search Instance;

    private void start()
    {
        DFSAlgo();
    }

    private void DFSAlgo()
    {
        currentNode = GameManager.Instance.Nodes[0];
        currentDir = currentNode.transform.position - transform.position;
        currentDir = currentDir.normalized;

        nodeList.Add(currentNode);

    }
    private void Awake()
    {
        /*if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("you can only have one");
            gameObject.SetActive(false);
        }
    }
        
}*/
