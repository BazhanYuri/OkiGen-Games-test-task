using System;
using System.Collections;
using UnityEngine;





namespace TestTask
{
    public enum FruitType
    {
        Apple,
        Pear,
        Orange
    }


    public class Fruit : MonoBehaviour
    {
        [SerializeField] private FruitTookPopUp _fruitTookPopUp;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private LayerChanger _layerChanger;

        [SerializeField] private Transform[] _skins;


        public static event Action<FruitType> FruitDropped;


        private FruitType _fruitType;
        public LayerChanger LayerChanger { get => _layerChanger;}
        public FruitType FruitType { get => _fruitType; private set => _fruitType = value; }


        private bool _isInBasket = false;



        public void ThrowInBasket(Transform basket)
        {
            _rigidbody.isKinematic = false;
            transform.parent = basket;
            FruitDropped?.Invoke(FruitType);
            StartCoroutine(SetAsInBasket());

            Instantiate(_fruitTookPopUp).transform.position = transform.position;
        }
        public void SetRandomFruit()
        {
            FruitType = (FruitType)UnityEngine.Random.Range(0, 3);

            SetSkin();
        }


        private void Update()
        {
            if (_isInBasket == true)
            {
                FreezeObject();
            }
        }
        private void FreezeObject()
        {
            if (_rigidbody == null)
            {
                return;
            }
            if (_rigidbody.velocity.magnitude < 0.1f)
            {
                Destroy(_rigidbody);
            }
        }
        private IEnumerator SetAsInBasket()
        {
            yield return new WaitForSeconds(1);
            _layerChanger.SetLayer(6);
            _isInBasket = true;
        }
        private void SetSkin()
        {
            for (int i = 0; i < _skins.Length; i++)
            {
                _skins[i].gameObject.SetActive(false);
            }
            switch (FruitType)
            {
                case FruitType.Apple:
                    _skins[0].gameObject.SetActive(true);
                    break;
                case FruitType.Pear:
                    _skins[1].gameObject.SetActive(true);
                    break;
                case FruitType.Orange:
                    _skins[2].gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
}

