using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private InputActionAsset input;
        [SerializeField] private Transform playerOrientation;
        [SerializeField] private float sensitivity;
        private InputAction _lookAction;
        private float _rotationX;
        private float _rotationY;

        // Start is called before the first frame update
        void Start()
        {
            _lookAction = input.FindActionMap("Player").FindAction("Look");
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = playerOrientation.position + new Vector3(0,0.35f,0);
            AimCamera();
        }

        void AimCamera()
        {
            Vector2 mouseInput = _lookAction.ReadValue<Vector2>() * sensitivity;
            _rotationX -= mouseInput.y;
            _rotationX = Mathf.Clamp(_rotationX, -90, 90);

            _rotationY += mouseInput.x;
            transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
            playerOrientation.rotation = Quaternion.Euler(0, _rotationY, 0);
        }
    }
}
