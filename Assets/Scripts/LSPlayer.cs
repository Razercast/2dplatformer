using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public LSManager theManager;
    public MapPoint currentPoint;
    public float moveSpeed = 10f;

    public bool levelLoading=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f && !levelLoading) { 

            if(Input.GetAxisRaw("Horizontal")>0.5f)
            {
                if(currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }

            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                Debug.Log("test");
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }

        }
        //Выбор уровня
        if(currentPoint.isLevel && currentPoint.levelToLoad!="" && !currentPoint.isLocked)
        {
            if(Input.GetButtonDown("Jump"))
            {
                levelLoading = true;
                theManager.LoadLevel();
            }
        }


    }

    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
    }
}
