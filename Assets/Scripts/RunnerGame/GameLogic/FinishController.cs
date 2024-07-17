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
                Time.timeScale = 0f;
                _finishScreenCanvas.gameObject.SetActive(true);
            }
            
        }
   
    }

}
