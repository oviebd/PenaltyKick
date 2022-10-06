using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, ICollisionEnter
{


    //public float factor = 100;

    //private float startTime;
    //private Vector3 startPos;


    Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

    [SerializeField]
    float throwForceInXandY = 1f; // to control throw force in X and Y directions

    [SerializeField]
    float throwForceInZ = 50f; // to control throw force in Z direction
    public Rigidbody rigidbody;
    private bool isScoredByThisBall = false;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchTimeFinish = Time.time;

            // calculate swipe time interval 
            timeInterval = touchTimeFinish - touchTimeStart;

            // getting release finger position
            endPos = Input.mousePosition;

            // calculating swipe direction in 2D space
            direction = startPos - endPos;

            // add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
            rigidbody.isKinematic = false;
            rigidbody.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);

           
            StartCoroutine(OnComplete());
        }


        //if (Input.GetMouseButtonDown(0))
        //{
        //    startTime = Time.time;
        //    startPos = Input.mousePosition;
        //    startPos.z = transform.position.z - Camera.main.transform.position.z;
        //    startPos = Camera.main.ScreenToWorldPoint(startPos);
        // //   Debug.Log("Pos >> " + Input.mousePosition);
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    var endPos = Input.mousePosition;
        //    endPos.z = transform.position.z - Camera.main.transform.position.z;
        //    endPos = Camera.main.ScreenToWorldPoint(endPos);

        //    Vector3 force = endPos - startPos;
        //    force.z = force.magnitude;
        //    force.Normalize();
        //    force /= (Time.time - startTime);

      
        //    rigidbody.AddForce(force * factor);
        //    StartCoroutine(ReturnBall());
        //}
    }

    //void OnMouseDown()
    //{
    //    startTime = Time.time;
    //    startPos = Input.mousePosition;
    //    startPos.z = transform.position.z - Camera.main.transform.position.z;
    //    startPos = Camera.main.ScreenToWorldPoint(startPos);
    //}

    //void OnMouseUp()
    //{
    //    var endPos = Input.mousePosition;
    //    endPos.z = transform.position.z - Camera.main.transform.position.z;
    //    endPos = Camera.main.ScreenToWorldPoint(endPos);

    //    Vector3 force = endPos - startPos;
    //    force.z = force.magnitude;
    //    force.Normalize();
    //    force /= (Time.time - startTime);


    //    rigidbody.AddForce(force * factor);
    //    StartCoroutine(ReturnBall());
    //}

    IEnumerator OnComplete()
    {
        yield return new WaitForSeconds(4.0f);

        GameManager.shared.OnBallKicked(isScoredByThisBall);
        Destroy(gameObject);
    }

    public void onCollisionEnter(GameObject collidedObj)
    {
        IScore scoreItem = collidedObj.GetComponent<IScore>();
        if (scoreItem != null && isScoredByThisBall == false)
        {
            isScoredByThisBall = true;
            GameManager.shared.GetGameInstances().scoreManager.AddScore(scoreItem.GetPoint());
            //GameManager.shared.GetGameInstances().uiManager.UpdateKickCountUi(1, KickCountUiItem.ITEM_TYPE.RIGHT);
            Debug.Log("U>> Yahoo goallll");
        }
    }
}
