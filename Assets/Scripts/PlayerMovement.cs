using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Serialize Field makes the variable visible to Unity whilst allowing for the variable to remain private
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float rotateSpeed = 1;
    private CharacterController characterController;
    private Camera playerCamera;

    //Copied from another script, might take a little to get it properly functional - T
    public Vector2 turnSpeed = new Vector2(1, 1);

    public Vector2 degreeClamp = new Vector2(90, 80);

    public bool invertY;

    Quaternion initialOrientation;
    Vector2 currentAngles;

    CursorLockMode previousLockState;
    private bool wasCursorVisible;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        OnEnable();
    }
    void Update()
    {
        playerCamera.transform.eulerAngles += 5 * new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);

        transform.eulerAngles += 5 * new Vector3(0, Input.GetAxis("Mouse X"));

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        characterController.Move(transform.forward * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        characterController.Move(transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime);
        characterController.SimpleMove(Physics.gravity);
    }

    void OnEnable() // This locks the cursor to the middle of the screen and makes it invisible
    {
        initialOrientation = transform.localRotation;

        previousLockState = Cursor.lockState;
        wasCursorVisible = Cursor.visible;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable() //This undoes the OnEnable
    {
        Cursor.visible = wasCursorVisible;
        Cursor.lockState = previousLockState;
        transform.localRotation = initialOrientation;
    }
}

