using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SphereMove : MonoBehaviour
{
    SphereControlls sphereControl;
    private InputAction steer, jump, startDash, stopDash, openLevelChoose;
    Rigidbody rbSphere;
    Vector3 forceVector;
    Vector3 JumpVector;
    [SerializeField] float height;
    [SerializeField] GameObject timer;
    float dashing;
    bool isDashing;
    Timer time;
    bool onGround;

    private void Awake()
    {
        sphereControl = new SphereControlls();
        rbSphere = GetComponent<Rigidbody>();
        time = timer.GetComponent<Timer>();
        
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

        openLevelChoose = sphereControl.Player.OpenLevelChoose;
        openLevelChoose.Enable();
        openLevelChoose.performed += OpenLevelChoose;

        JumpVector = Vector3.up;
    }

    private void OnDisable()
    {
        steer.Disable();
        jump.Disable();
        startDash.Disable();
        stopDash.Disable();
        openLevelChoose.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        JumpVector = Vector3.up;
        dashing = 1.5f;
    }

    private void FixedUpdate()
    {
        if (isDashing == true) rbSphere.velocity = new Vector3(forceVector.x * 8f, rbSphere.velocity.y, 7f * dashing);
        else rbSphere.velocity = new Vector3(forceVector.x * 8f, rbSphere.velocity.y, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        forceVector = steer.ReadValue<Vector3>();
       
    }

    void OpenLevelChoose(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("LevelChoose");
    }

    void Jump (InputAction.CallbackContext context)
    {
        if (onGround == true)
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

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionExit(Collision other)
    {
        onGround = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            if (time.time < PlayerPrefs.GetFloat("Record"))
            {
                PlayerPrefs.SetFloat("Record", time.time);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.CompareTag("Deathplane"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
