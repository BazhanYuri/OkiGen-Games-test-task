using System;
using UnityEngine;





namespace TestTask
{
    public class GameManager : MonoBehaviour
    {
        public static event Action GamePlayStarted;
        public static event Action LevelCompleted;
        public static event Action LevelWinned;
        public static event Action LevelFailed;




        private void OnEnable()
        {
            TaskManager.TaskCompleted += CheckCompletedStatus;
        }
        private void OnDisable()
        {
            TaskManager.TaskCompleted -= CheckCompletedStatus;
        }


        private void Start()
        {
            GamePlayStarted?.Invoke();
        }
        private void CheckCompletedStatus(TaskStatus taskStatus)
        {
            LevelCompleted?.Invoke();
            switch (taskStatus)
            {
                case TaskStatus.Winned:
                    LevelWinned?.Invoke();
                    break;
                case TaskStatus.Failed:
                    LevelFailed?.Invoke();
                    break;
                default:
                    break;
            }
        }
        
    }
}

