using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    public GameObject u;
    public NewBehaviourScript script;
    public static move manager;
    //  public GameObject bgm;
    public CharacterController characterController;
    // Start is called before the first frame update
    public bool stay;
    public Rigidbody rb;
    public bool attack;
    public bool roll;
    public bool pow;
    public bool q;
    public float up;
    public float damege;
    public float j;
    public float jump;
    public float g;
    public float length;
    Vector3 velocity = Vector3.zero;
    public Transform c;
    public Transform gc;
    private float _speed;
    private float _animationBlend;
    private float _targetRotation = 0.0f;
    private float _rotationVelocity;
    public float _verticalVelocity;
    private float _terminalVelocity = 53.0f;
    public float RotationSmoothTime = 0.12f;
    public float currentHorizontalSpeed;


  /*  [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;
    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;
    [Tooltip("For locking the camera position on all axis")]
    public bool LockCameraPosition = false;
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;
    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    private StarterAssetsInputs _input;
    public GameObject _mainCamera;
    private PlayerInput _playerInput;
    private const float _threshold = 0.01f;
    */
  /*  private bool IsCurrentDeviceMouse
    {
        get
        {
                return _playerInput.currentControlScheme == "KeyboardMouse";
        }
    }*/
    
    // enum Mode
    //{ move, attack, tallk } 
    public float t = 1;
    public float speed = 2;
    public float RS = 2;
    void Start()
    {
      /*  _playerInput = GetComponent<PlayerInput>();
        _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
        _input = GetComponent<StarterAssetsInputs>();  */
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        if (manager == null)
        {
            manager = this;
        }
    }
    void FixedUpdate()
    {
        // Mode mode = Mode.move;
        if (t > -1)
        {
            t = t - Time.deltaTime;
        }

        //   if (Input.GetKeyDown(KeyCode.Mouse0))
        //   {
        //      Instantiate(bgm, transform.position, Quaternion.identity);
        //    t = 1.1f;
        //   attack = true;
        //   }
        /* else */
        if (t <= 0)
        {
            attack = false;
        }
        else
        {
            attack = true;
        }
        if (!attack)

        //   if (Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //      mode = mode + 1;
        //  }
        // if (Input.GetKeyDown(KeyCode.F))
        //  {
        //      mode = mode + 2;
        // }
        // switch (mode)
        // {
        // case Mode.move:
        {
            if (GameObject.Find("QUEST 2") == null)
            {
                charmove();
                Onslope();
            }
            /* if (Input.GetKey(KeyCode.D))
             {

                 Vector3 newPos = new Vector3();
                 newPos.x = gameObject.transform.position.x + speed;
                 newPos.y = gameObject.transform.position.y;
                 newPos.z = gameObject.transform.position.z;
                 gameObject.transform.SetPositionAndRotation(newPos, gameObject.transform.rotation);
                 transform.rotation = Quaternion.Euler(0, 90, 0);
             }
             else if (Input.GetKeyUp(KeyCode.D))
             {
                 transform.rotation = Quaternion.Euler(0, 0, 0);
             }
             if (Input.GetKey(KeyCode.A))
             {//rb.velocity = Vector3.left * 500;
                 Vector3 newPos = new Vector3();
                 newPos.x = gameObject.transform.position.x - speed;
                 newPos.y = gameObject.transform.position.y;
                 newPos.z = gameObject.transform.position.z;
                 gameObject.transform.SetPositionAndRotation(newPos, gameObject.transform.rotation);
                 transform.rotation = Quaternion.Euler(0, -90, 0);
             }
             else if (Input.GetKeyUp(KeyCode.A))
             {
                 transform.rotation = Quaternion.Euler(0, 0, 0);
             }
             if (Input.GetKey(KeyCode.W))
             {
                 //  characterController.SimpleMove(transform.forward*100);
                 Vector3 newPos = new Vector3();
                 newPos.x = gameObject.transform.position.x;
                 newPos.y = gameObject.transform.position.y;
                 newPos.z = gameObject.transform.position.z + speed;
                 gameObject.transform.SetPositionAndRotation(newPos, gameObject.transform.rotation);
                 transform.rotation = Quaternion.Euler(0, 0, 0);
                 //rb.velocity = Vector3.forward * 500;
             }
             if (Input.GetKey(KeyCode.S))
             {
                 //  characterController.SimpleMove(transform.forward * -100);
                 Vector3 newPos = new Vector3();
                 newPos.x = gameObject.transform.position.x;
                 newPos.y = gameObject.transform.position.y;
                 newPos.z = gameObject.transform.position.z - speed;
                 gameObject.transform.SetPositionAndRotation(newPos, gameObject.transform.rotation);
                 transform.rotation = Quaternion.Euler(0, 180, 0);
                 // rb.velocity = Vector3.back * 500;
             }
             */
            if (Input.GetKeyDown(KeyCode.Space))
            {
                j = GetComponent<Transform>().position.y;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                //  characterController.SimpleMove(transform.forward*100);
                Vector3 newPos = new Vector3();
                newPos.x = gameObject.transform.position.x;
                newPos.y = gameObject.transform.position.y + (Input.GetAxisRaw("Jump")*jump);
                newPos.z = gameObject.transform.position.z;
                gameObject.transform.SetPositionAndRotation(newPos, gameObject.transform.rotation);
            }
        }
        else
        {
            stay = false;
        }

        //   rb.AddForce(Vector3.down * 25000);
        if (up > 0)
        {
            up = up - Time.deltaTime;
            damege = 15;
        }
        else if (up <= 0)
        {   
            pow = false;
            damege = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LoadLevel")
        {
            Application.LoadLevel(other.name);
        }
        if (other.tag == "trade")
        {
            q = false;

        }
       /* else if (other.tag == "Ground")
        {
            q = true;

        }*/
        if (other.name == "drive")
        {
            if (TMP.ctrl.m == "c")
            {
                TMP.ctrl.getscore(1);
            }
        }
    }
    public void getscore(float value)
    {
        t = value;
    }

    public void end(float value)
    {
        script.Mouse(false);
        Application.LoadLevel("001");
        Destroy(u);
    }
    public void powup(float value)
    {
        if (!pow)
        {
            pow = true;
        }
        up = value;
    }
    private void charmove()
    {
        if (!stay)
        {
            if (velocity.y > -150)
            {
                velocity.y -= g * Time.deltaTime;
            }
            characterController.Move(velocity);

        }
        else
        {

            velocity.y = 0;
        }
        if (q)
      {


            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                q = false;
            }
            /* var horizontal = Input.GetAxis("Horizontal");
             var vertical = Input.GetAxis("Vertical");
             var move = transform.forward * speed * vertical * Time.deltaTime;
             characterController.Move(move);
             transform.Rotate(Vector3.up, horizontal * RS);*/
            Vector3 newPos = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical")).normalized;
             //var move = newPos * speed * Time.deltaTime;
            var move1 = c.transform.right * speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            var move2 = c.transform.forward * speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
            Vector3 target = Vector3.Lerp(transform.forward, newPos, RS * Time.deltaTime);
            //  characterConmove3troller.Move(move1 + move2);
            /*  Vector3 jp = new Vector3(0, Input.GetAxis("Jump"),0).normalized;
              var ju = jp * jump * Time.deltaTime;
              characterController.Move(ju);*/
            if (newPos != Vector3.zero)
        {

                _targetRotation = Mathf.Atan2(newPos.x, newPos.z) * Mathf.Rad2Deg +c.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    RotationSmoothTime);

                // rotate to face input direction relative to camera position
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
                //        transform.rotation = Quaternion.LookRotation(target);
                // Quaternion rotation = Quaternion.LookRotation(newPos, Vector3.up);
            }
        //    Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.down;
            characterController.Move(move1 + move2);

        }
        else
        {
            if(Input.GetAxisRaw("Horizontal") != 0 | Input.GetAxisRaw("Vertical") != 0)
            {
                q = true;
            }
        }
    }
    private void Onslope()
       {
        Ray ray = new Ray(gc.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, length))
        {
            float slopeangle = Vector3.Angle(hit.normal, Vector3.up);
            stay = true;
        }
        else
        {
            stay = false;
        }
      }
  /*  private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
            _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }*/
  /*  private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
    private void LateUpdate()
    {
        CameraRotation();
    }*/
}

