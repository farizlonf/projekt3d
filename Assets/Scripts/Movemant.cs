using UnityEngine;

public class Movemant : MonoBehaviour
{

    Vector3 test;

    GameObject player;

    Transform CameraTransform;

    Transform ShotGunTransform;

    CharacterController control;

    Rigidbody body;

    [SerializeField] float PlayerSpeed;






    [SerializeField] public float mouseSensitivity;

    private float cameraPitch = 0f; //starting camera rotation (1 axies)




    void Start()
    {

        player = GameObject.Find("PlayerMesh");

        control = GameObject.Find("PlayerMesh").GetComponent<CharacterController>();

        CameraTransform = GameObject.Find("FPS Cam").GetComponent<Transform>();

        ShotGunTransform = GameObject.Find("ShotGun").GetComponent<Transform>();

        body = GameObject.Find("PlayerMesh").GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

    }

    void Update()
    {

        //CameraAngle

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate player left/right (affects movement direction)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera up/down (just visual, doesn't affect movement)
        cameraPitch -= mouseY; //mijenjanje vrijednosti camera rotacije jedanog axisa pomocu inputa 

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f); // Limit looking straight up/down

        CameraTransform.localEulerAngles = Vector3.right * cameraPitch; //mijenjaje transform vrijednosti da se object stvarno rotira

        ShotGunTransform.localEulerAngles = Vector3.forward * cameraPitch + new Vector3(0, 90, -3); //paralelno s kamerom transformamo rotation sotke

        //ShotGunTransform.position =  new Vector3(ShotGunTransform.position.x,ShotGunTransform.position.y,cameraPitch*0.01f);



        //Movemant

        //Raw instant response no filtering
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 forward = CameraTransform.forward;

        Vector3 right = CameraTransform.right;

        forward.y = 0f;

        right.y = 0f;

        forward.Normalize();

        right.Normalize();

        Vector3 moveDirection = (forward * verticalInput) + (right * horizontalInput);    

        control.Move(moveDirection * PlayerSpeed * Time.deltaTime); //dodavanje forca character control objectu (3d vektor) u smjeru vektora gdje pointa ali limitirano na 2 axisa

    }
}
