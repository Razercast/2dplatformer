using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;
    public Transform farBackground, middleBackground;

    public bool stopFollow;

    public float minHeight = -1.5f, maxHeight = 1.5f;

    //private float lastXPos;
    private Vector2 lastPos;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x,clampedY,transform.position.z);*/
        if (!stopFollow)
        {
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            //float amountToMoveX = transform.position.x - lastXPos;
            Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);



            farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
            middleBackground.position += new Vector3(amountToMove.x * .5f, amountToMove.y, 0f) * 0.5f;

            lastPos = transform.position;
        }
    }
}
