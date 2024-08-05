using UnityEngine;
using UnityEngine.InputSystem;

namespace RunnerGame
{
    /// <summary>
    /// класс отвечающий за инпут игрока, он берёт с инпут системы значения и то, какие кнопки мы нажали, а другие классы могут обращаться к этим значениям через менеджера
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public class InputManager : MonoBehaviour
    {
        public static PlayerInput PlayerInput;

        public static Vector2 Movement;

        private InputAction _moveAction;

        //Получаем компоненты отвечающие за движение
        private void Awake()
        {
            PlayerInput
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

