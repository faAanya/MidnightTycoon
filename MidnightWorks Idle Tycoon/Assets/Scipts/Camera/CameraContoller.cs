using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public bool isRot = false;
    private Vector3 str;
    private void OnMouseDrag()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

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

            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + (aimVector - str), .5f);
        }
    }
}
