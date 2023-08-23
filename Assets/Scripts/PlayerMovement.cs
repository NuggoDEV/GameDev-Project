using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // Serialize Field makes the variable visible to Unity whilst allowing for the variable to remain private
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float rotateSpeed = 1;

    private void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        characterController.Move(transform.forward * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        characterController.SimpleMove(Physics.gravity);
    }
}
