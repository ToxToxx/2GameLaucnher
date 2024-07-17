using UnityEngine;
using UnityEngine.InputSystem;

namespace RunnerGame
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : MonoBehaviour
    {
        public static PlayerInput PlayerInput;

        public static Vector2 Movement;

        private InputAction _moveAction;

        //Получаем компоненты отвечающие за движение
        private void Awake()
        {
            PlayerInput = GetComponent<PlayerInput>();
            _moveAction = PlayerInput.actions["Move"];
        }

        //Считываем значения для движения
        private void Update()
        {
            Movement = _moveAction.ReadValue<Vector2>();
        }
    }
}

