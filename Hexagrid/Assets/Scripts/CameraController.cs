using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraMoveSpeed = 10f;
    [SerializeField] private float cameraRotationSpeed = 100f;
    [SerializeField] private float zoomSpeed = 1f;

    [SerializeField] CinemachineVirtualCamera cinemachineVirtual;

    private const float MAX_FOLLOW_Y = 12f;
    private const float MIN_FOLLOW_Y = 2f;

    private Vector3 targetOffset;
    private CinemachineTransposer cinemachineTransposer;


    private void Start()
    {
        cinemachineTransposer = cinemachineVirtual.GetCinemachineComponent<CinemachineTransposer>();
        targetOffset = cinemachineTransposer.m_FollowOffset;

    }
    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    private void HandleZoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            targetOffset.y -= zoomSpeed;
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            targetOffset.y += zoomSpeed;
        }

        targetOffset.y = Mathf.Clamp(targetOffset.y, MIN_FOLLOW_Y, MAX_FOLLOW_Y);

        float smoothTime = 5f;
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetOffset, Time.deltaTime * smoothTime);
    }

    private void HandleRotation()
    {
        Vector3 rotationInput = new(0, 0, 0);
        if (Input.GetKey(KeyCode.Q))
        {
            rotationInput.y += 1f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationInput.y -= 1f;
        }

        transform.eulerAngles += cameraRotationSpeed * Time.deltaTime * rotationInput;
    }

    private void HandleMovement()
    {
        Vector3 movementInput = new(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            movementInput.z += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementInput.z -= 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementInput.x += 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementInput.x -= 1f;
        }

        Vector3 moveVector = transform.forward * movementInput.z + transform.right * movementInput.x;
        transform.position += cameraMoveSpeed * Time.deltaTime * moveVector;
    }
}