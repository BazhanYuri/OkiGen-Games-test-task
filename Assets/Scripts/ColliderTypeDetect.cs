using UnityEngine;


public enum GameObjectType
{
    Fruit,
    Null
}
public class ColliderTypeDetect : MonoBehaviour
{
    [SerializeField] private Transform _root;
    [SerializeField] private GameObjectType _type;

    public GameObjectType Type { get => _type; }
    public Transform Root { get => _root; }
}