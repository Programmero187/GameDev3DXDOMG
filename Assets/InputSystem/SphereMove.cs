using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereMove : MonoBehaviour
{
    SphereControlls sphereControl;
    private InputAction steer, jump, startDash, stopDash;
    Rigidbody rbSphere;
    Vector3 forceVector;
    Vector3 JumpVector;
    [SerializeField] float height;
    float dashing;
    bool isDashing;

    private void Awake()
    {
        sphereControl = new SphereControlls();
        rbSphere = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        steer = sphereControl.Player.Move;
        steer.Enable();

        jump = sphereControl.Player.Fire;
        jump.Enable();
        jump.performed += Jump;

        startDash = sphereControl.Player.DashGo;
        startDash.Enable();
        startDash.performed += DashRejuvinated;

        stopDash = sphereControl.Player.DashStop;
        stopDash.Enable();
        stopDash.performed += DashCeased;

        JumpVector = Vector3.up;
    }
    // Start is called before the first frame update
    void Start()
    {
        JumpVector = Vector3.up;
        dashing = 1.5f;
    }

    private void FixedUpdate()
    {
        if (isDashing == true) rbSphere.velocity = new Vector3(forceVector.x * 8f, rbSphere.velocity.y, 10f * dashing);
        else rbSphere.velocity = new Vector3(forceVector.x * 8f, rbSphere.velocity.y, 10f);
    }

    // Update is called once per frame
    void Update()
    {
       forceVector = steer.ReadValue<Vector3>();
    }

    void Jump (InputAction.CallbackContext context)
    {
        if(rbSphere.velocity.y == 0f)
        {
            rbSphere.AddForce(JumpVector * height);
        }
    }

    void DashCeased (InputAction.CallbackContext context)
    {
        isDashing = false;
    }

    void DashRejuvinated(InputAction.CallbackContext context)
    {
        isDashing = true;
    }
}
