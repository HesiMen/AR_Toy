using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNext : MonoBehaviour
{
    private bool wallFront;
    private bool wallBack;
    private bool wallRight;
    private bool wallLeft;

    [SerializeField] GameObject cyl;
    [SerializeField] GameObject bigcyl;
    [SerializeField] GameObject rightCube;
    [SerializeField] GameObject leftCube;
    [SerializeField] GameObject capsule;
    

    private float wallUnitDistanceCheck;
    
    [HideInInspector]
    public float  pitchChange;
    [HideInInspector]
    public float  speedChange;
    [HideInInspector]
    public float distortChange;

    private float distortChangeY;

    // Start is called before the first frame update
    void Start()
    {
        wallUnitDistanceCheck = 1;
        pitchChange = 1f;
        speedChange = 1f;
        distortChange = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        WallCheck();
        // Debug.Log(pitchChange);
       // Debug.Log("SpeedChange in CheckNext: "+speedChange);
    }

    void WallCheck()
    {


        RaycastHit hitFront;
        RaycastHit hitBack;
        RaycastHit hitRight;
        RaycastHit hitLeft;

        Vector3 front = transform.TransformDirection(Vector3.forward);
        Vector3 back = transform.TransformDirection(Vector3.back);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 left = transform.TransformDirection(Vector3.left);

        var frontRay = Physics.Raycast(transform.position, front, out hitFront, wallUnitDistanceCheck);
        var backRay = Physics.Raycast(transform.position, back, out hitBack, wallUnitDistanceCheck);
        var rightRay = Physics.Raycast(transform.position, right, out hitRight, wallUnitDistanceCheck);
        var leftRay = Physics.Raycast(transform.position, left, out hitLeft, wallUnitDistanceCheck);

        if (frontRay)
        {
            Debug.Log("Something is on top");
            float changeinHeight = .05f / hitFront.distance;
            pitchChange =  .1f /hitFront.distance;
            
            cyl.transform.localScale = new Vector3 (.1f, changeinHeight, .1f );
            bigcyl.transform.localScale = new Vector3 (.3f, changeinHeight, .3f );
            Debug.Log(pitchChange);
        }
        else
        {
            Debug.DrawRay(transform.position, front * wallUnitDistanceCheck, Color.blue);
            //Debug.Log(hitFront.distance);
            pitchChange = 1f ;
            cyl.transform.localScale = new Vector3(.1f, .1f, .1f);
            bigcyl.transform.localScale = new Vector3(.3f, .3f, .3f);
            wallFront = false;
        }

        if (backRay)
        {
           // Debug.Log("Something is on Bottom");
            distortChangeY = hitBack.distance+.5f;
            distortChange = (.5f/hitBack.distance) * 50f;
            capsule.transform.localScale = new Vector3(.22f, distortChangeY, .22f);
            //Debug.Log("Back Distort Changee : " + distortChange);
        }
        else
        {
            Debug.DrawRay(transform.position, back * wallUnitDistanceCheck, Color.white);
            distortChange = 0f;
            capsule.transform.localScale = new Vector3(.22f, .22f, .22f);

            wallBack = false;
        }
        if (rightRay)
        {
           // Debug.Log("Something is to the right");
            speedChange =Mathf.Abs(2f - (hitRight.distance * 10f));
            rightCube.transform.localScale = new Vector3(speedChange , .1f, .1f);
          //  Debug.Log("Right: " + speedChange);


        }
        else
        {
            //Debug.DrawRay(transform.position, right * wallUnitDistanceCheck, Color.cyan);
            wallRight = false;
            rightCube.transform.localScale = new Vector3(.24f, .1f, .1f);
            // speedChange = 1f;
        }
        if (leftRay)
        {
           // Debug.Log("Something is to the left");
            //change this to left
            speedChange =Mathf.Abs(2f - (hitLeft.distance * 10f));
            leftCube.transform.localScale = new Vector3(-speedChange, .1f, .1f);
           // Debug.Log("left: " + speedChange);

        }
        else
        {
            //Debug.DrawRay(transform.position, left * wallUnitDistanceCheck, Color.yellow);
            wallLeft = false;
            leftCube.transform.localScale = new Vector3(-.24f, .1f, .1f);
            // speedChange = 1f;
        }
    }
}
