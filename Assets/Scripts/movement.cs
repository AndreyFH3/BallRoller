using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class movement : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    [SerializeField] private float _speed;
    [SerializeField] private Transform moveToDirection;
    
    private BallController ballController ;

    private void Awake()
    {
        ballController = new BallController();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballController.BallMove.Clicked.performed += _ => { if (Physics.Raycast(transform.position, Vector3.down, 1f)) rb.AddForce(Vector3.up * 10, ForceMode.Impulse); };
    }

    private void OnDisable()
    {
        ballController.Disable();
    }

    private void OnEnable()
    {
        ballController.Enable();
    }

    private void Update()
    {
        MoveBall();
    }

    private Vector3 GetDirection()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");
        Vector2 direct = ballController.BallMove.GetInput.ReadValue<Vector2>();
        return direction(moveToDirection.TransformDirection(new Vector3(direct.x, 0, direct.y)));

    }
    private Vector3 direction(Vector3 forward)
    {
        Vector3 normal = new Vector3();
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            normal = hit.normal;
        }
        return forward - Vector3.Dot(forward, normal) * normal;
    }

    private void MoveBall()
    {
        rb.AddForce(_speed * Time.deltaTime * GetDirection() , ForceMode.Force);
    }

}
