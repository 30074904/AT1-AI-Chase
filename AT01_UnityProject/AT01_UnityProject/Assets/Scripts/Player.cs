using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Define delegate types and events here

    public Node CurrentNode { get; private set; }
    [SerializeField] public Node TargetNode { get; private set; }

    float x_move = 0f;
    float y_move = 0f;

    [SerializeField] private float speed = 4;
    private bool moving = false;
    private Vector3 currentDir;

    public bool bleft;
    public bool bright;
    public bool bup;
    public bool bdown;

    private void Awake()
    {
        TargetNode = CurrentNode;
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.GoMoveEvent += Inputs;

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
            x_move = Input.GetAxis("Horizontal");
            y_move = Input.GetAxis("Vertical");
            Inputs(0);
            
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
                transform.position = CurrentNode.tLocation;
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
    void Inputs(int direction)
    {
        if (moving == false)
        {
            RaycastHit hit;
            if (x_move < 0 | direction == 1)
            {
                if (Physics.Raycast(transform.position, Vector3.left, out hit, 10))
                {
                    MoveToNode(hit.collider.gameObject.GetComponent<Node>());
                    EventManager.updateColorEvent(Color.green, 1);
                    direction = 0;
                }
                else
                {
                    EventManager.updateColorEvent(Color.red, 1);
                }
            }
            if (x_move > 0 | direction == 2)
            {
                if (Physics.Raycast(transform.position, Vector3.right, out hit, 10))
                {
                    MoveToNode(hit.collider.gameObject.GetComponent<Node>());
                    EventManager.updateColorEvent(Color.green, 2);
                    direction = 0;
                }
                else
                {
                    EventManager.updateColorEvent(Color.red, 2);
                }
            }
            if (y_move > 0 | direction == 3)
            {
                if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10))
                {
                    MoveToNode(hit.collider.gameObject.GetComponent<Node>());
                    EventManager.updateColorEvent(Color.green, 3);
                    direction = 0;
                }
                else
                {
                    EventManager.updateColorEvent(Color.red, 3);
                }
            }
            if (y_move < 0 | direction == 4)
            {
                if (Physics.Raycast(transform.position, Vector3.back, out hit, 10))
                {
                    MoveToNode(hit.collider.gameObject.GetComponent<Node>());
                    EventManager.updateColorEvent(Color.green, 4);
                    direction = 0;
                }
                else
                {
                    EventManager.updateColorEvent(Color.red, 4);
                }
            }
        }
        

        


    }
    public void buttonpush(int potatoe)
    {

        Inputs(potatoe);
    }
}
