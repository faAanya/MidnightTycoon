using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StationUIController : MonoBehaviour
{
    public GameObject stationUI;
    private Camera _mainCamera;

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
                stationUI.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }

}
