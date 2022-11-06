
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private float rayRadius;
    [SerializeField] private WinManager winManager;

    private Camera _cam;
    private Chip _chip;


    private LayerMask _layerHouse;
    private LayerMask _layerPlane;



    private void Awake()
    {
        _cam = Camera.main;
        _layerHouse = LayerMask.GetMask("Chip");
        _layerPlane = LayerMask.GetMask("Plane");
    }
    private void Update()
    {

            if (InputController.Instance.GetPointerDown)
            {
                Ray rayChip = _cam.ScreenPointToRay(InputController.Instance.PointerPosition);
                RaycastHit hitChip;

                if (Physics.SphereCast(rayChip, rayRadius, out hitChip, Mathf.Infinity, _layerHouse))
                {
                    _chip = hitChip.transform.GetComponent<Chip>();
                    _chip.ActiveDrag(true);
                }
            }
            else if (InputController.Instance.GetPointerUp)
            {
                winManager.CheckCountChip();
                if (_chip != null)
                {
                    _chip.ActiveDrag(false);
                    _chip.SnapToGrid(true);
                    _chip = null;
                }
            }
    }

    private void FixedUpdate()
    {

            if (InputController.Instance.GetPointerHeld)
            {
                Ray rayPlane = _cam.ScreenPointToRay(InputController.Instance.PointerPosition);
                RaycastHit hitPlane;
                if (Physics.SphereCast(rayPlane, rayRadius, out hitPlane, Mathf.Infinity, _layerPlane))
                {
                    if (_chip != null)
                    {
                        _chip.Move(speed, hitPlane.point);
                    }
                }
            }

    }
}
