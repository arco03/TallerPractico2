using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _scripts.Player
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [Header("Values Configuration")]
        [SerializeField] private float normalSpeed;
        [SerializeField] private float sprintSpeed;
        [SerializeField] private float sprintDuration;
        [SerializeField] private float rechargeSprintTime;
        [SerializeField] private float rotationX;

        private Transform _playerCamera;
        private Rigidbody _rb;
        private float _currentSpeed;
        [HideInInspector] public float currentEnergy;
        [HideInInspector] public bool canRun = true;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            _playerCamera = Camera.main?.transform;

            _currentSpeed = normalSpeed;
            currentEnergy = sprintDuration;
        }
    
        public void Rotation(float mouseX, float mouseY)
        {
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            _playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
        
        public void Move(float horizontal, float vertical)
        {
            Vector3 movement = transform.right * horizontal + transform.forward * vertical;
            movement *= _currentSpeed;
            
            Vector3 newSpeed = new Vector3(movement.x, _rb.velocity.y, movement.z);
            _rb.velocity = newSpeed;
        }

        public void CanRun()
        {
            _currentSpeed = sprintSpeed;
            currentEnergy -= Time.deltaTime;

            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                canRun = false;
                _currentSpeed = normalSpeed;
            }
        }
        
        public void CantRun()
        {
            _currentSpeed = normalSpeed;
            
            if (currentEnergy < sprintDuration)
            {
                currentEnergy += (sprintDuration / rechargeSprintTime) * Time.deltaTime;
                if (currentEnergy >= sprintDuration)
                {
                    currentEnergy = sprintDuration;
                    canRun = true;
                }
            }
        }
    }
}
