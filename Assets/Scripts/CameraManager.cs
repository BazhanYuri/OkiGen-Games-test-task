using UnityEngine;




namespace TestTask
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Transform _completedCamera;




        private void OnEnable()
        {
            GameManager.LevelCompleted += ShowCompletedCamera;
        }
        private void OnDisable()
        {
            GameManager.LevelCompleted -= ShowCompletedCamera;
        }
        private void ShowCompletedCamera()
        {
            _completedCamera.gameObject.SetActive(true);
        }
    }
}

