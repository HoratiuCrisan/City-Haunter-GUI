using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float speed = 80;
    public float rotationSpeed = 360;

    [SerializeField]
    private Transform cameraTransform;

    private void Update()
    {
        // get input values for movement 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //set the direction movement 
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);


        movementDirection = Quaternion.AngleAxis(cameraTransform.eulerAngles.y, Vector3.up) * movementDirection;

        //normalize the movement direction vector (set magnitute to 1)
        movementDirection.Normalize();

        //change the position based on the movement
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
    
        //check for player movement
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            //rotate to face the direction of moving

        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
