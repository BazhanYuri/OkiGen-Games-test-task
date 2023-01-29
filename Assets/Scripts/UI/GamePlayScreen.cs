using UnityEngine;
using DG.Tweening;
using TMPro;





namespace TestTask
{
    public class GamePlayScreen : Screen
    {
        [SerializeField] private TextMeshProUGUI _applesCount;
        [SerializeField] private TextMeshProUGUI _pearsCount;
        [SerializeField] private TextMeshProUGUI _orangeCount;

        public TextMeshProUGUI ApplesCount { get => _applesCount;}
        public TextMeshProUGUI PearsCount { get => _pearsCount;}
        public TextMeshProUGUI OrangeCount { get => _orangeCount;}

        private void OnEnable()
        {
            GameManager.GamePlayStarted += StartShowing;
            GameManager.LevelCompleted += StartHidding;
        }
        private void OnDisable()
        {
            GameManager.GamePlayStarted -= StartShowing;
            GameManager.LevelCompleted -= StartHidding;
        }




        public void UpdateText(TextMeshProUGUI field, int count)
        {
            field.transform.parent.DOPunchScale(Vector3.one * 0.3f, 0.2f, 2);
            string text = "";
            Color color = Color.white;

            if (count > 0)
            {
                text += "x";
                color = Color.white;
                SoundManager.Instance.PlayRightFruit();
            }
            if (count < 0)
            {
                color = Color.red;
                SoundManager.Instance.PlayFailFruit();
            }
            if (count == 0)
            {
                text += "+";
                color = Color.green;
                SoundManager.Instance.PlayRightFruit();
            }
            text += count;

            field.text = text;
            field.color = color;
        }
    }
}

