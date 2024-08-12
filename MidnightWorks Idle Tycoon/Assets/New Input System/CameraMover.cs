using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMover : MonoBehaviour
{

    private Camera _mainCamera;

    public bool mouseClicked = false;

    public bool isRot = false;
    private Vector3 str;

    [Range(0, .01f)]
    public float speed;

    private void Awake()
    {

        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            mouseClicked = true;
        }
        else if (context.canceled)
        {
            mouseClicked = false;
        }
    }

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        Vector2 pos = context.ReadValue<Vector2>();
        Debug.Log(pos);
        if (mouseClicked)
        {
            isRot = true;
            str = pos;
        }
        else if (!mouseClicked)
        {
            isRot = false;
        }
        if (isRot && Time.timeScale != 0f)
        {
            Vector3 aimVector = pos;
            Vector3 myVec = new Vector3((gameObject.transform.position.x + pos.x), gameObject.transform.position.y, (gameObject.transform.position.z + pos.y));
            Vector3 vector3 = Quaternion.AngleAxis(0, Vector3.up) * myVec;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, vector3, speed);
        }
    }
}