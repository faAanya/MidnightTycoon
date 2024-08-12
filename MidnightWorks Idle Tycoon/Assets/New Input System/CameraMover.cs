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
            gameObject.transform.position -= new Vector3(pos.x, 0, pos.y) * 0.01f;
        }
    }
}