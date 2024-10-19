using UnityEngine;

namespace WeaponFramework
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private GameObject viewmodel;
        [SerializeField] private Transform aimPoint;
        [SerializeField] private Vector3 viewmodelOffset;
        [SerializeField] private Vector3 aimOffset;
        [SerializeField] private float aimSpeed;
        [SerializeField]private bool aiming;
        
        private Vector3 _idlePosition;
        private Vector3 _aimPosition;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            viewmodel.transform.SetParent(mainCamera.transform, false);
            _idlePosition = viewmodelOffset;
            CalculateAimPosition();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateViewmodel();
        }

        void UpdateViewmodel()
        {
            if (aiming)
            {
                viewmodel.transform.localPosition = Vector3.Lerp(viewmodel.transform.localPosition, _aimPosition + aimOffset, Time.deltaTime * aimSpeed);
            }
            else
            {
                viewmodel.transform.localPosition = Vector3.Lerp(viewmodel.transform.localPosition, viewmodelOffset, Time.deltaTime * aimSpeed);
            }
        }

        void CalculateAimPosition() 
        {
            _aimPosition = -aimPoint.localPosition;
            
        }
    }
}
