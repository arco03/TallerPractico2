using System;
using UnityEngine;

namespace _scripts
{
    //have the player logic
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour
    {
        [Header("Values Configuration")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationX;

        private Transform _playerCamera;
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            
            Cursor.lockState = CursorLockMode.Locked;
            _playerCamera = Camera.main?.transform;
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
            movement *= movementSpeed;
            
            Vector3 newSpeed = new Vector3(movement.x, _rb.velocity.y, movement.z);
            _rb.velocity = newSpeed;
        }
    }
}
