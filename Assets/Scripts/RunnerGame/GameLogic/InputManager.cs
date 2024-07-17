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

        //�������� ���������� ���������� �� ��������
        private void Awake()
        {
            PlayerInput = GetComponent<PlayerInput>();
            _moveAction = PlayerInput.actions["Move"];
        }

        //��������� �������� ��� ��������
        private void Update()
        {
            Movement = _moveAction.ReadValue<Vector2>();
        }
    }
}

