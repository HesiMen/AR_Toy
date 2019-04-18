using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------Make a list of transform from [0] -> [1] -> [2] -> [3] 

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;


    public List<Transform> transforms; // Use this list to get origins and destination! =) Almost there Hesi! 
 
    public Transform origin;
    public Transform destination;
    
    
    public float lineDrawSpeed =6f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);

        lineRenderer.startWidth = .45f;
        lineRenderer.endWidth = .45f;

        dist = Vector3.Distance(origin.position, destination.position);



    }

    // Update is called once per frame
    void Update()
    {
        
           
            Vector3 pointA = origin.position;
            Vector3 pointB = destination.position;

            Vector3 pointAlongLine = (pointB - pointA) + pointA;

       
        
        lineRenderer.SetPosition(1, pointAlongLine);

    }


    public void AddPosList(Transform lilCube)
    {
        Debug.Log("point Added");
        transforms.Add(lilCube);
    }

    public void DeListPos(Transform lilCube)
    {
        transforms.Remove(lilCube);
    }
}
