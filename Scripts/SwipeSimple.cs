using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwipeSimple : MonoBehaviour
{


    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;

    public bool detectSwipeAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;




    // Update is called once per frame
    void Update()
    {
        //Touch
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            //Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }

            //Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                DetectSwipe();
            }
        }
        // Mouse for Debug purposes
        if (Input.GetMouseButtonDown(0) && Application.isPlaying)
        {
			fingerUpPos =  new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			
        }
		if(Input.GetMouseButtonUp(0) && Application.isPlaying) 
		{
			fingerDownPos =  new Vector2(Input.mousePosition.x,Input.mousePosition.y);
			DetectSwipe();
		}



    }

    void DetectSwipe()
    {

        if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            Debug.Log("Vertical Swipe Detected!");
            if (fingerDownPos.y - fingerUpPos.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
                OnSwipeDown();
            }
            fingerUpPos = fingerDownPos;

        }
        else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            Debug.Log("Horizontal Swipe Detected!");
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;

        }
        else
        {
            Debug.Log("No Swipe Detected!");
        }
    }

    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }



	public delegate void upSwipeEvent();
	public static event upSwipeEvent OnSwipedUp;
    void OnSwipeUp()
    {
		if(OnSwipedUp!= null){OnSwipedUp();}
        Debug.Log("UP");
        //Do something when swiped up
    }

	public delegate void downSwipeEvent();
	public static event downSwipeEvent OnSwipedDown;
    void OnSwipeDown()
    {
		if(OnSwipedDown!= null){OnSwipedDown();}
           Debug.Log("DOWN");
        //Do something when swiped down
    }

	public delegate void leftSwipeEvent();
	public static event leftSwipeEvent OnSwipedLeft;
    void OnSwipeLeft()
    {
		if(OnSwipedLeft!= null){OnSwipedLeft();}
           Debug.Log("LEFT");
        //Do something when swiped left
    }
	public delegate void rightSwipeEvent();
	public static event rightSwipeEvent OnSwipedRight;
    
    void OnSwipeRight()
    {
		if(OnSwipedRight!= null){OnSwipedRight();}
        Debug.Log("RIGHT");
        //Do something when swiped right
    }
}
