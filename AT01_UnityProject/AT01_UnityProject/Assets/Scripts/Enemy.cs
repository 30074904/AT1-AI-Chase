using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Movement speed modifier.")]
    [SerializeField] private float speed = 3;
    private Node currentNode;
    private Vector3 currentDir;
    private bool playerCaught = false;

    // Custom variables start

    [SerializeField] private Node startNode;
    [SerializeField] private Player player;

    public bool started = false;

    private Node tempNode;
    // Custom varialbles end

    public delegate void GameEndDelegate();
    public event GameEndDelegate GameOverEvent = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        InitializeAgent();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCaught == false)
        {
            if (currentNode != null)
            {
                //If within 0.25 units of the current node.
                if (Vector3.Distance(transform.position, currentNode.transform.position) > 0.25f)
                {
                    transform.Translate(currentDir * speed * Time.deltaTime);
                    if (started == false)
                    {
                        DFSAlgo(startNode);
                    }
                    else
                    {
                        DFSAlgo(tempNode);
                        started = true;
                    }

                }

                //Implement path finding here
            }
            else
            {
                Debug.LogWarning($"{name} - No current node");
            }

            Debug.DrawRay(transform.position, currentDir, Color.cyan);
        }
    }

    //Called when a collider enters this object's trigger collider.
    //Player or enemy must have rigidbody for this to function correctly.
    private void OnTriggerEnter(Collider other)
    {
        if (playerCaught == false)
        {
            if (other.tag == "Player")
            {
                playerCaught = true;
                GameOverEvent.Invoke(); //invoke the game over event
            }
        }
    }

    /// <summary>
    /// Sets the current node to the first in the Game Managers node list.
    /// Sets the current movement direction to the direction of the current node.
    /// </summary>
    void InitializeAgent()
    {
        currentNode = GameManager.Instance.Nodes[0];
        currentDir = currentNode.transform.position - transform.position;
        currentDir = currentDir.normalized;
    }
    void DFSAlgo(Node currNode)
    {
        // create lists of nodes visited and nodes in the stack
        List<Node> visitedNodes = new List<Node>();
        List<Node> stackNodes = new List<Node>();

        List<Node> childrenNodes = new List<Node>();

        Node playerDestination;

        //Node currNode = startNode;

        playerDestination = player.TargetNode;
        
        visitedNodes.Add(currNode);

        if (currNode != playerDestination)
        {
            
            visitedNodes.Add(currNode);
            childrenNodes = currNode.listChildren;

            if (childrenNodes != null)
            {
                foreach (Node node in childrenNodes)
                {
                    if (!visitedNodes.Contains(node))
                    {
                        if (!stackNodes.Contains(node))
                        {
                            stackNodes.Add(node);
                        }
                    }
                }
                tempNode = stackNodes[stackNodes.Count - 1];
            }
            else
            {
                stackNodes.Remove(stackNodes[stackNodes.Count - 1]);
                tempNode = stackNodes[stackNodes.Count - 1];
            }
            
        }
        else
        {
            currentNode = currNode;
            currentDir = currentNode.transform.position - transform.position;
            currentDir = currentDir.normalized;
        }
        
    }
    //Implement DFS algorithm method here
}
