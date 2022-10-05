using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{


    public float factor = 100;

    private float startTime;
    private Vector3 startPos;


    public Rigidbody rigidbody;

    void OnMouseDown()
    {
        startTime = Time.time;
        startPos = Input.mousePosition;
        startPos.z = transform.position.z - Camera.main.transform.position.z;
        startPos = Camera.main.ScreenToWorldPoint(startPos);
    }

    void OnMouseUp()
    {
        var endPos = Input.mousePosition;
        endPos.z = transform.position.z - Camera.main.transform.position.z;
        endPos = Camera.main.ScreenToWorldPoint(endPos);

        Vector3 force = endPos - startPos;
        force.z = force.magnitude;
        force.Normalize();
        force /= (Time.time - startTime);


        rigidbody.AddForce(force * factor);
        StartCoroutine(ReturnBall());
    }

    IEnumerator ReturnBall()
    {
        yield return new WaitForSeconds(4.0f);
        transform.position = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
    }

}
