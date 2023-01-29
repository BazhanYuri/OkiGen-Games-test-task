using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





namespace TestTask
{
    public class WinScreen : Screen
    {
        [SerializeField] private Button _nextLevel;


        private void OnEnable()
        {
            _nextLevel.onClick.AddListener(LoadNextLevel);
            GameManager.LevelWinned += StartShowing;
        }
        private void OnDisable()
        {
            _nextLevel.onClick.RemoveListener(LoadNextLevel);
            GameManager.LevelWinned -= StartShowing;
        }

        private void LoadNextLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}

