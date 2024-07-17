using UnityEngine;

namespace RunnerGame
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _playerMoveSpeed = 5f;
        private Rigidbody _playerRigidbody;

        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector2 movement = InputManager.Movement;

            Vector3 moveDirection = new(movement.x, 0, movement.y);

            _playerRigidbody.velocity = moveDirection * _playerMoveSpeed;
        }
    }
}
