using System.Collections;
using UnityEngine;



namespace TestTask
{
    public class FruitsSpawner : MonoBehaviour
    {
        [SerializeField] private FruitsPool _fruitsPool;
        [SerializeField] private float _timeToSpawnFruit;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _visual;





        private void OnEnable()
        {
            GameManager.GamePlayStarted += StartSpawn;
            GameManager.LevelCompleted += StopSpawning;
        }
        private void OnDisable()
        {
            GameManager.GamePlayStarted -= StartSpawn;
            GameManager.LevelCompleted -= StopSpawning;
        }



        private void StartSpawn()
        {
            StartCoroutine(Spawning());
        }
        private IEnumerator Spawning()
        {
            while (true)
            {
                print("spawning");
                yield return new WaitForSeconds(_timeToSpawnFruit);
                Fruit fruit = _fruitsPool.GetPooledObject();
                fruit.SetRandomFruit();
                fruit.transform.position = _spawnPoint.position;
                fruit.transform.parent = _visual;
            }
        }
        private void StopSpawning()
        {
            StopAllCoroutines();
        }
    }
}

