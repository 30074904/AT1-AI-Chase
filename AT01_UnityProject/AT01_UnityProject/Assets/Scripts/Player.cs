using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Define delegate types and events here

    public Node CurrentNode { get; private set; }
    [SerializeField] public Node TargetNode { get; private set; }


    [SerializeField] private float speed = 4;
    private bool moving = false;
    private Vector3 currentDir;
    private void Awake()
    {
        TargetNode = CurrentNode;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (Node node in GameManager.Instance.Nodes)
        {
            if(node.Parents.Length > 2 && node.Children.Length == 0)
            {
                CurrentNode = node;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == false)
        {
            //Implement inputs and event-callbacks here
            Inputs();
            
        }
        else
        {
            if (Vector3.Distance(transform.position, TargetNode.transform.position) > 0.25f)
            {
                transform.Translate(currentDir * speed * Time.deltaTime);
            }
            else
            {
                moving = false;
                CurrentNode = TargetNode;
            }
        }
    }

    //Implement mouse interaction method here

    /// <summary>
    /// Sets the players target node and current directon to the specified node.
    /// </summary>
    /// <param name="node"></param>
    public void MoveToNode(Node node)
    {
        if (moving == false)
        {
            TargetNode = node;
            currentDir = TargetNode.transform.position - transform.position;
            currentDir = currentDir.normalized;
            moving = true;
        }
    }
    void Inputs()
    {
        RaycastHit hit;
        float x_move = Input.GetAxis("Horizontal");
        float y_move = Input.GetAxis("Vertical");

        GameObject nHit;

        if (x_move > 0)
        {
            
            if (Physics.Raycast(transform.position, Vector3.left, out hit, 10))
            {
                Debug.Log("Right");
            }
        }
        if (x_move < 0)
        {
            if (Physics.Raycast(transform.position, Vector3.right, out hit, 10))
            {
                nHit = hit;
                MoveToNode(hit);
                Debug.Log("Left");
            }
        }

    }
}
