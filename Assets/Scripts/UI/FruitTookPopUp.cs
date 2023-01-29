using UnityEngine;
using DG.Tweening;





namespace TestTask
{
    public class FruitTookPopUp : MonoBehaviour
    {
        [SerializeField] private Transform _canvas;


        private void OnEnable()
        {
            _canvas.LookAt(Camera.main.transform);
            _canvas.DOLocalMoveY(1, 0.5f).OnComplete(() => Destroy(gameObject));
        }
    }
}

