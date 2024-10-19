using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _rb;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float damping;
        [SerializeField] private InputActionAsset actionAsset;
        private InputAction _moveAction;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody>();
            _moveAction = actionAsset.FindActionMap("Player").FindAction("Move");
        }
    
        // Update is called once per frame
        void Update()
        {
            LimitSpeed();
        }

        void FixedUpdate()
        {
            Move();
        }

        void Move()
        {
            Vector2 inputDirection = _moveAction.ReadValue<Vector2>();
            if (inputDirection.Equals(Vector2.zero)) // Stop moving Quicker
            {
                _rb.linearDamping = damping * 2;
            }
            else
            {
                _rb.linearDamping = damping;
                Vector3 direction = inputDirection.x * transform.right + inputDirection.y * transform.forward;
                _rb.AddForce(direction.normalized * moveSpeed);
            }
        }
    
        void LimitSpeed()
        {
            Vector3 flatVel = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);

            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                _rb.linearVelocity = new Vector3(limitedVel.x, _rb.linearVelocity.y, limitedVel.z);
            }
        }
    }
}
