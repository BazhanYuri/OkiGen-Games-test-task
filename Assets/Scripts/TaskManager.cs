using UnityEngine;




namespace TestTask
{

    public enum TaskStatus
    {
        Winned,
        Failed
    }
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private int _minCount;
        [SerializeField] private int _maxCount;
        [SerializeField] private GamePlayScreen _gamePlayScreen;

        public static event System.Action<TaskStatus> TaskCompleted;


        private int _countOfApples;
        private int _countOfPears;
        private int _countOfOranges;

        private int _allFruitsCount;





        private void OnEnable()
        {
            GameManager.GamePlayStarted += GenerateRandomTask;
            Fruit.FruitDropped += CheckDroppedFruit;
        }
        private void OnDisable()
        {
            GameManager.GamePlayStarted -= GenerateRandomTask;
            Fruit.FruitDropped -= CheckDroppedFruit;
        }


        private void GenerateRandomTask()
        {
            _countOfApples = Random.Range(_minCount, _maxCount);
            _countOfPears = Random.Range(_minCount, _maxCount);
            _countOfOranges = Random.Range(_minCount, _maxCount);
            _allFruitsCount = _countOfApples + _countOfPears + _countOfOranges;
            SetTextes();
        }
        private void CheckDroppedFruit(FruitType fruitType)
        {
            _allFruitsCount--;

            switch (fruitType)
            {
                case FruitType.Apple:
                    _countOfApples--;
                    _gamePlayScreen.UpdateText(_gamePlayScreen.ApplesCount, _countOfApples);
                    break;
                case FruitType.Pear:
                    _countOfPears--;
                    _gamePlayScreen.UpdateText(_gamePlayScreen.PearsCount, _countOfPears);
                    break;
                case FruitType.Orange:
                    _countOfOranges--;
                    _gamePlayScreen.UpdateText(_gamePlayScreen.OrangeCount, _countOfOranges);
                    break;
                default:
                    break;
            }
            CheckState();
        }
        private void SetTextes()
        {
            _gamePlayScreen.ApplesCount.text = "x"+_countOfApples.ToString();
            _gamePlayScreen.PearsCount.text = "x"+ _countOfPears.ToString();
            _gamePlayScreen.OrangeCount.text = "x"+ _countOfOranges.ToString();
        }
        private void CheckState()
        {
            if (_allFruitsCount == 0)
            {
                if (Mathf.Abs(_countOfApples) + Mathf.Abs(_countOfPears) + Mathf.Abs(_countOfOranges) == 0)
                {
                    TaskCompleted?.Invoke(TaskStatus.Winned);
                }
                else
                {
                    TaskCompleted?.Invoke(TaskStatus.Failed);
                }
            }
        }
    }
}

