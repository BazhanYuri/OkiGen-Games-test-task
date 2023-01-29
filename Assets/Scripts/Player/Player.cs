using UnityEngine;
using DG.Tweening;
using DitzelGames.FastIK;





namespace TestTask
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private FastIKFabric _iKFabric;
        [SerializeField] private Rigidbody _basketHandler;
        [SerializeField] private Transform _crown;




        private void OnEnable()
        {
            GameManager.LevelWinned += StartDancing;
        }
        private void OnDisable()
        {
            GameManager.LevelWinned -= StartDancing;
        }


        private void StartDancing()
        {
            _animator.SetTrigger("Dance");
            _iKFabric.enabled = false;
            _basketHandler.transform.parent = null;
            _basketHandler.isKinematic = false;


            _crown.transform.localPosition += new Vector3(0, 3, 0);
            _crown.gameObject.SetActive(true);
            _crown.transform.DOLocalMoveY(1.072f, 0.7f);
        }
    }

}
