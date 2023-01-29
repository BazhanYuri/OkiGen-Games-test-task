using UnityEngine;




namespace TestTask
{
    public class LayerChanger : MonoBehaviour
    {
       public void SetLayer(int layer)
       {
            foreach (Transform g in transform.GetComponentsInChildren<Transform>())
            {
                g.gameObject.layer = layer;
            }
            foreach (Transform child in transform)
            {
                child.gameObject.layer = layer;
            }
        }
    }
}

