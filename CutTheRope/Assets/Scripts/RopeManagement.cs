using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManagement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D firstHook;
    [SerializeField] private Ball ball;
    [SerializeField] private int numJoint=5;
    public GameObject[] linkPool; 
    public string hingeName;
    void Start()
    {
        Rope_Create();
    }

    void Rope_Create()
    {
        Rigidbody2D beforeLink = firstHook;
        for (int i = 0; i < numJoint; i++)
        {
            linkPool[i].SetActive(true);
            
            HingeJoint2D joint = linkPool[i].GetComponent<HingeJoint2D>();
            joint.connectedBody = beforeLink;

            if(i < numJoint -1)
            {
                beforeLink = linkPool[i].GetComponent<Rigidbody2D>();
            }
            else
            {
                ball.ConnectLastChain(linkPool[i].GetComponent<Rigidbody2D>(),hingeName);
            }
        }

    }
}
