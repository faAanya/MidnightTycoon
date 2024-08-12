using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public bool isRot = false;
    private Vector3 str;

    [Range(0, .01f)]
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("True");
            isRot = true;
            str = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRot = false;
        }
        if (isRot)
        {
            Vector3 aimVector = Input.mousePosition;
            Vector3 myVec = new Vector3((gameObject.transform.position.x + (str - aimVector).x), gameObject.transform.position.y, (gameObject.transform.position.z + (str - aimVector).y));
            Vector3 vector3 = Quaternion.AngleAxis(45, Vector3.up) * myVec;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, vector3, speed);
        }
    }
}
