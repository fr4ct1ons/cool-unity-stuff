using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBBullet : MonoBehaviour
{
    // Vars.
    [SerializeField]
    float backspinDrag = 0.0001f;
    bool isShooted = false, isStoped;

    Vector3 force, initPos, lastDebugPost;

    Rigidbody toHopUp;

    public void IsShooted(Vector3 force)
    {
        if (isShooted == false)
        {
            isShooted = true;
            this.force = force;
            toHopUp.useGravity = true;
            toHopUp.AddForce(this.force, ForceMode.Impulse);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        toHopUp = this.gameObject.GetComponent<Rigidbody>();
        this.initPos = this.lastDebugPost = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShooted && isStoped == false)
        {
            // Magnum Effect.
            Backspin();
        }
        /*
        if (toHopUp.velocity.magnitude < 0.01f)
        {
            isStoped = true;
        }
        */
    }

    void Backspin()
    {
        // Calcs. lead...
        Vector3 hopUpForce = new Vector3(0, Mathf.Sqrt(toHopUp.velocity.magnitude), 0);
        toHopUp.AddForce(hopUpForce * backspinDrag * Time.deltaTime);        

        Debug.DrawLine(lastDebugPost, this.transform.position, Color.red, 5);
        lastDebugPost = transform.position;
    }
}
