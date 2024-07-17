using UnityEngine;

namespace RunnerGame
{
    public class FinishController : MonoBehaviour
    {
        [SerializeField] private Canvas _finishScreenCanvas;

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
