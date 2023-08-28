using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Serialize Field makes the variable visible to Unity whilst allowing for the variable to remain private
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float rotateSpeed = 1;
    private CharacterController characterController;
    private Camera playerCamera;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

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
}
