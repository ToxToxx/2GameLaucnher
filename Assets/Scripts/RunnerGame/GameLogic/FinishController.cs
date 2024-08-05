using UnityEngine;

namespace RunnerGame
{
    /// <summary>
    /// Class responsible for the behavior logic of the finish object - the destination point for our hero. Stops time and displays the victory screen.
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
