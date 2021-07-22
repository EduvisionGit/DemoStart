using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    //TODO: Delete follower when off screen
    Node [] Nodes;
    float speed = 2f;
    Vector3 nextNodePosition;
    int indexInNodes = 0;
    bool follow = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject path = GameObject.Find("Path");
        Nodes = path.GetComponentsInChildren<Node>();
        Debug.Log("Nodes: " + Nodes.Length.ToString());
        nextNodePosition = Nodes[indexInNodes].transform.position;
    }

    public void MakeIdle(){
        follow = false;
    }

    bool isApproximatelyEqual(double x, double y, double margin){
        return y >= x-margin && y<= x+margin;
    }
    void moveTowardsNextNode(){
        //need slope then simply alter x and y at certain rate relative to slope
        Vector3 slope = nextNodePosition - transform.position;
        slope = slope.normalized;
        transform.Translate(Time.deltaTime*slope.x*speed, Time.deltaTime*slope.y*speed, 0);
    }
    void progressToNextNode(){
        if(!follow){
            return;
        }
        if(isApproximatelyEqual(nextNodePosition.x, transform.position.x, .1)
        && isApproximatelyEqual(nextNodePosition.y, transform.position.y, .1)){
            indexInNodes++;
            indexInNodes = indexInNodes%Nodes.Length;
            nextNodePosition = Nodes[indexInNodes].transform.position;
        }        
        else{
            moveTowardsNextNode();
            // transform.position = Vector3.Lerp(transform.position, nextNodePosition, Time.deltaTime *speed);
        }
    }
    void Update()
    {
     progressToNextNode();   
    }
}
