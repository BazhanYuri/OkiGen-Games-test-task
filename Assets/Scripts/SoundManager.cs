using System.Collections;
using UnityEngine;




namespace TestTask
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _wrongFruit;
        [SerializeField] private AudioSource _rightFruit;
        [SerializeField] private AudioSource _winSound;

        public static SoundManager Instance;




        private void OnEnable()
        {
            GameManager.LevelWinned += WinMusic;
        }
        private void OnDisable()
        {
            GameManager.LevelWinned -= WinMusic;
        }

        private void Start()
        {
            Instance = this;
        }


        public void PlayFailFruit()
        {
            PlaySound(_wrongFruit, 3);
        }
        public void PlayRightFruit()
        {
            PlaySound(_rightFruit, 3);
        }

        private void WinMusic()
        {
            PlaySound(_winSound, -1);
        }

        private void PlaySound(AudioSource audioSource, float timeToDestroy)
        {
            StartCoroutine(Play(audioSource, timeToDestroy));
        }
        private IEnumerator Play(AudioSource audioSource, float timeToDestroy)
        {
            AudioSource audio = Instantiate(audioSource);
            audio.Play();

            if (timeToDestroy != -1)
            {
                yield return new WaitForSeconds(timeToDestroy);
                Destroy(audio);
            }
        }
    }
}

