using UnityEngine;

namespace RunnerGame
{
    /// <summary>
    /// Класс отвечающий за логику поведения объекта финиша - точки назначения нашего героя. Останавливает время и показывает экран победы.
    /// </summary>
    public class FinishController : MonoBehaviour
    {
        [SerializeField] private Canvas _finishScreenCanvas;

        private void Start()
        {
            _finishScreenCanvas.gameObject.SetActive(false);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerMovementController>())
            {
                TimeController.Instance.StopTimer();         
                _finishScreenCanvas.gameObject.SetActive(true);
            }
            
        }
   
    }

}
