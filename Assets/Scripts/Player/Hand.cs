using UnityEngine;
using DG.Tweening;




namespace TestTask
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] private Transform _pointToFollow;
        [SerializeField] private Transform _pointThrow;
        [SerializeField] private Transform _basketPoint;
        [SerializeField] private Transform _hand;

        [SerializeField] private float _takingSpeed;
        [SerializeField] private float _afterTakingSpeed;

        private Fruit _fruit;
        private Vector3 _handPointStandartPos;
        private bool _isTakingFruit = false;


        private void OnEnable()
        {
            InputManager.ObjectTouched += TakeFruit;
        }
        private void OnDisable()
        {
            InputManager.ObjectTouched -= TakeFruit;
        }




        private void Start()
        {
            _handPointStandartPos = _pointToFollow.position;
        }

        private void TakeFruit(TouchedObjInfo touchedObjInfo)
        {
            _isTakingFruit = true;

            _fruit = touchedObjInfo.transform.GetComponent<Fruit>();

            Tweener tweener = _pointToFollow.DOMove(touchedObjInfo.transform.position + new Vector3(0, 0.3f, 0), _takingSpeed).OnComplete(() => SetFruitParent()).SetEase(Ease.Linear);

            tweener.OnUpdate(delegate () {
                if (Vector3.Distance(_hand.position, touchedObjInfo.transform.position) > 3)
                {
                    RejectTaking();
                    tweener.Kill();
                }
                if (Vector3.Distance(_hand.position, touchedObjInfo.transform.position) < 0.5f)
                {
                    print("killed");
                    SetFruitParent();
                    tweener.Kill();
                }
                tweener.ChangeEndValue(touchedObjInfo.transform.position + new Vector3(0, 0.3f, 0), true);
            });
        }

        private void SetFruitParent()
        {
            _fruit.transform.parent = _hand;
            _pointToFollow.DOMove(_pointThrow.position, _afterTakingSpeed).OnComplete(() => ThrowFruit());
        }
        private void ThrowFruit()
        {
            _fruit.transform.parent = null;
            _fruit.transform.localScale = Vector3.one * 0.7f;
            _fruit.transform.DOMove(_basketPoint.position, 0.3f).OnComplete(() => _fruit.ThrowInBasket(_basketPoint.parent)).SetEase(Ease.Linear);
            _pointToFollow.DOMove(_handPointStandartPos, _afterTakingSpeed).SetEase(Ease.Linear);

            _isTakingFruit = false;
        }
        private void RejectTaking()
        {
            _fruit.transform.parent = null;
            _isTakingFruit = false;
            _pointToFollow.DOMove(_handPointStandartPos, _afterTakingSpeed).SetEase(Ease.Linear);
        }
    }

}
