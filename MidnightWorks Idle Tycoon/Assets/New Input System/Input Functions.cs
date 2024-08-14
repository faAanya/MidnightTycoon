using UnityEngine;
using UnityEngine.InputSystem;

public class InputFunctions : MonoBehaviour
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

        if (context.started && Time.timeScale != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Station")
            {
                Debug.Log(hit.transform.name);
                hit.transform.gameObject.GetComponent<Station>().stationUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
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
            Vector3 myVec = pos;
            Vector3 vector3 = Quaternion.AngleAxis(45, Vector3.up) * myVec;
            _mainCamera.transform.position = Vector3.Lerp(gameObject.transform.position, vector3, speed);
        }
    }
}