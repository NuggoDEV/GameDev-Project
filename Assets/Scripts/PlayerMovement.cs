using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Serialize Field makes the variable visible to Unity whilst allowing for the variable to remain private
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float rotateSpeed = 1;
    private CharacterController characterController;
    public bool lockCamera = false;
    private float yRotation = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Prevent cursor from moving
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        // Camera rotating
        if (!lockCamera)
        {
            transform.eulerAngles += 5 * new Vector3(0, Input.GetAxis("Mouse X"));
            
            yRotation += -Input.GetAxis("Mouse Y") * 5;
            yRotation = Mathf.Clamp(yRotation, -45, 45);
            Camera.main.transform.eulerAngles = new Vector3(yRotation, transform.eulerAngles.y, 0);
        }

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
        characterController.Move(transform.forward * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        characterController.Move(transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime);
        characterController.SimpleMove(Physics.gravity);
    }
}

