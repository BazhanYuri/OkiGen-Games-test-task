using System;
using UnityEngine;
using DG.Tweening;




namespace TestTask
{
    public class TransporterMovement : MonoBehaviour
    {
        [SerializeField] private Transform _visual;
        [SerializeField] private float _step;
        [SerializeField] private float _speed;


        private void OnEnable()
        {
            GameManager.LevelCompleted += StopMoving;
        }
        private void OnDisable()
        {
            GameManager.LevelCompleted -= StopMoving;
        }

        
        private void FixedUpdate()
        {
            MoveLines();
        }
        private void MoveLines()
        {
            _visual.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Line line))
            {
                line.transform.Translate(Vector3.right * _step);
            }
        }
        private void StopMoving()
        {
            _speed = 0;
            _visual.parent.DOMoveY(-7, 4);
        }
    }
}

