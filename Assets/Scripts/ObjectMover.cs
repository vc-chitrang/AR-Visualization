using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectMover : MonoBehaviour {
    public GameObject ObjectToMove;
    public float moveSpeed = 5f;
    public float rotationSpeed = 90f;  // degrees per second
    public Camera mainCamera;  // Assign the main camera in the Inspector
    public float distanceFromCamera = 2f;

    private bool moveForward;
    private bool moveReverse;
    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool rotateClockwise;
    private bool rotateCounterclockwise;

    void Update() {
        Vector3 moveDirection = Vector3.zero;

        if (moveForward)
            moveDirection += Vector3.forward;
        if (moveReverse)
            moveDirection += Vector3.back;
        if (moveUp)
            moveDirection += Vector3.up;
        if (moveDown)
            moveDirection += Vector3.down;
        if (moveLeft)
            moveDirection += Vector3.left;
        if (moveRight)
            moveDirection += Vector3.right;

        ObjectToMove.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (rotateClockwise)
           ObjectToMove.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        if (rotateCounterclockwise)
            ObjectToMove.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }

    public void OnForwardButtonDown() {
        moveForward = true;
    }
    public void OnForwardButtonUp() {
        moveForward = false;
    }
    public void OnReverseButtonDown() {
        moveReverse = true;
    }
    public void OnReverseButtonUp() {
        moveReverse = false;
    }
    public void OnUpButtonDown() {
        moveUp = true;
    }
    public void OnUpButtonUp() {
        moveUp = false;
    }
    public void OnDownButtonDown() {
        moveDown = true;
    }
    public void OnDownButtonUp() {
        moveDown = false;
    }
    public void OnLeftButtonDown() {
        moveLeft = true;
    }
    public void OnLeftButtonUp() {
        moveLeft = false;
    }
    public void OnRightButtonDown() {
        moveRight = true;
    }
    public void OnRightButtonUp() {
        moveRight = false;
    }

    public void OnRotateClockwiseButtonDown() {
        rotateClockwise = true;
    }
    public void OnRotateClockwiseButtonUp() {
        rotateClockwise = false;
    }
    public void OnRotateCounterclockwiseButtonDown() {
        rotateCounterclockwise = true;
    }
    public void OnRotateCounterclockwiseButtonUp() {
        rotateCounterclockwise = false;
    }

    public void PlaceInFrontOfCamera() {
        if (mainCamera != null) {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraPosition = mainCamera.transform.position;
            ObjectToMove.transform.position = cameraPosition + cameraForward * distanceFromCamera;
        } else {
            Debug.LogWarning("Main Camera is not assigned.");
        }
    }
}
