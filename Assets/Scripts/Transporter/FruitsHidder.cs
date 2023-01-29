using UnityEngine;





namespace TestTask
{
    public class FruitsHidder : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ColliderTypeDetect colliderType) && colliderType.Type == GameObjectType.Fruit)
            {
                colliderType.Root.gameObject.SetActive(false);
                colliderType.Root.parent = null;
            }
        }
    }
}

