using UnityEngine;
using UnityEngine.InputSystem;

namespace RunnerGame
{
    /// <summary>
    /// The class responsible for player input, it gets values from the input system and the buttons we pressed, and other classes can access these values through the manager.
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        public PlayerInput PlayerInput { get; private set; }
        public Vector2 Movement { get; private set; }

        private InputAction _moveAction;

        // Ensures that the instance is set and that the GameObject is not destroyed on scene load
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            InitializeInput();
        }

        private void InitializeInput()
        {
            PlayerInput = GetComponent<PlayerInput>();
            _moveAction = PlayerInput.actions["Move"];
            _moveAction.Enable();
        }

        // Enable and disable the move action
        private void OnEnable()
        {
            _moveAction?.Enable();
        }

        private void OnDisable()
        {
            _moveAction?.Disable();
        }

        // Reads the movement input value
        private void Update()
        {
            if (_moveAction != null)
                Movement = _moveAction.ReadValue<Vector2>();
        }
    }
}
