using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float distanceWithChain = 0.2f;
    public Dictionary<string,HingeJoint2D> HingeControl = new Dictionary<string, HingeJoint2D>();


    public void ConnectLastChain(Rigidbody2D lastChain,string HingeName)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>(); 
        HingeControl.Add(HingeName,joint);
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = lastChain;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f,-distanceWithChain);
    }
}
