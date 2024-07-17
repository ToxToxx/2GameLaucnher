using UnityEngine;


namespace RunnerGame
{
    public class FinishController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<PlayerMovementController>())
            {
                Time.timeScale = 0f;
            }
            
        }
   
    }

}
