using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyUtility;

public class Ball : MonoBehaviour, ICollisionEnter
{

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
            endPos = Input.mousePosition;
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            float distance = Vector3.Distance(startPos, endPos);
           // Debug.Log("U>> D - " + distance + " time " + timeInterval);

            //timeInterval <= .5 ||
            if ( distance < 100)
                return;

            // calculating swipe direction in 2D space
            direction = startPos - endPos;

            // add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
            rigidbody.isKinematic = false;
            rigidbody.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);

            GameManager.shared.GetGameInstances().soundManager.PlayKickSound();
           
            StartCoroutine(OnKickCompleteAction(4.0f,0));
        }
    }

  

    IEnumerator OnKickCompleteAction(float time, int score = 0)
    {
        yield return new WaitForSeconds(time);

        GameManager.shared.OnBallKicked(score);
        Destroy(gameObject);
    }

    public void onCollisionEnter(GameObject collidedObj)
    {
        if (isScoredByThisBall)
            return;

        IScore scoreItem = collidedObj.GetComponent<IScore>();

        if (scoreItem != null)
        {
            isScoredByThisBall = true;
            StopAllCoroutines();
            StartCoroutine(OnKickCompleteAction(2, scoreItem.GetPoint()));
        }
        //Debug.Log("U>> Yahoo goallll  " + collidedObj.gameObject.name);
        IReacatble reactable = collidedObj.GetComponent<IReacatble>();
        reactable?.ReactOnCollide();

    }
}
