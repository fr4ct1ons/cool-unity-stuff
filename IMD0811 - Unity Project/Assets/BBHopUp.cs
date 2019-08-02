using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBHopUp : MonoBehaviour
{
    [SerializeField] float BackspinDrag = 0.0001f;

    public AnimationCurve heightPlot = new AnimationCurve();

    Rigidbody myRigidbody;
    private Vector3 lastDebugPost;
    private Vector3 initPos;
         
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        initPos = lastDebugPost = transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("<color=red>" + GetComponent<Rigidbody>().velocity + "</color>");
        Debug.Log("<color=green>" + Mathf.Sqrt(myRigidbody.velocity.z) * BackspinDrag * Time.deltaTime + "</color>");
        myRigidbody.AddForce(0, Mathf.Sqrt(myRigidbody.velocity.magnitude) * BackspinDrag * Time.deltaTime ,0);
        Debug.Log("<color=yellow>" + transform.position.y + "</color>");
        heightPlot.AddKey(Time.realtimeSinceStartup, transform.position.y);
        Debug.DrawLine(lastDebugPost, transform.position, Color.red, 5);
        lastDebugPost = transform.position;
        //heightPlot.AddKey(Time.realtimeSinceStartup, transform.position.z);

        float dist = Vector3.Distance(initPos, transform.position);
        Debug.Log("Distancia " + dist);
    }

    private void OnDrawGizmos()
    {
        //.DrawSphere(lastDebugPost, transform.position,);
    }
}
