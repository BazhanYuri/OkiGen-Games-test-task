using System.Collections.Generic;
using UnityEngine;




namespace TestTask
{
    public class FruitsPool : MonoBehaviour
    {
        [SerializeField] private int _maxCount;
        [SerializeField] private Fruit _fruitPrefab;


        private List<Fruit> _fruits;

        public int MaxCount { get => _maxCount; }

        public Fruit GetPooledObject()
        {
            for (int i = 0; i < _maxCount; i++)
            {
                if (!_fruits[i].gameObject.activeInHierarchy)
                {
                    _fruits[i].gameObject.SetActive(true);
                    return _fruits[i];
                }
            }
            return null;
        }
        void Awake()
        {
            InitializePool();
        }



        private void InitializePool()
        {
            _fruits = new List<Fruit>();
            Fruit tmp;
            for (int i = 0; i < _maxCount; i++)
            {
                tmp = Instantiate(_fruitPrefab);
                tmp.gameObject.SetActive(false);
                _fruits.Add(tmp);
            }
        }
    }
}

