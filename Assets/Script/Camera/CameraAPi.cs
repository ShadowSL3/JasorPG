using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
public class CameraAPi : MonoBehaviour
{
    public RenderingPath pathRendering;
    public Camera cam;
    // zoom and zoom out camera API system
    public bool HDR = false;
    public bool MSAA = false;
    public Transform target;
    public float zoomSpeed;
    public float minZoom = 4f;
    public float maxZoom = 3.2f;
    public float moveSpeed = 3.5f;
    public Vector2 minLimit;
    public Vector2 maxLimit;


    //
    // Start is called before the first frame update
    void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        float zoomDelta = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - zoomDelta, minZoom, maxZoom);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Vector3 moveVector = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(moveVector);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minLimit.x, maxLimit.x);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minLimit.y, maxLimit.y);
        transform.position = clampedPosition;
    }

}
