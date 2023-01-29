using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



namespace TestTask
{
    public class FailScreen : Screen
    {
        [SerializeField] private Button _nextLevel;


        private void OnEnable()
        {
            _nextLevel.onClick.AddListener(LoadNextLevel);
            GameManager.LevelFailed += StartShowing;
        }
        private void OnDisable()
        {
            _nextLevel.onClick.RemoveListener(LoadNextLevel);
            GameManager.LevelFailed -= StartShowing;
        }

        private void LoadNextLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}

