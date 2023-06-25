using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NoName
{
    public class InputManager : MonoBehaviour, PlayerControls.IPlayerActions
    {
        public static InputManager Instance;

        private PlayerControls _playerControls;

        public Vector2 MoveInput { get; private set; }

        public event Action CancelEvent;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _playerControls = new();
            _playerControls.Player.SetCallbacks(this);
            _playerControls.Player.Enable();
        }

        private void OnDestroy()
        {
            _playerControls.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
        }

      
        public void OnLook(InputAction.CallbackContext context)
        {
            
        }


        public void OnCancel(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            CancelEvent?.Invoke();
        }
    }
}