using System;
using UnityEngine;





namespace TestTask
{
    public class TouchedObjInfo
    {
        public GameObjectType GameObjectType;
        public Transform transform;
        public Vector3 worldPos;


        public TouchedObjInfo(GameObjectType gameObjectType = GameObjectType.Null)
        {
            GameObjectType = gameObjectType;
        }
        public TouchedObjInfo(GameObjectType gameObjectType, Transform transform, Vector3 worldPos)
        {
            GameObjectType = gameObjectType;
            this.transform = transform;
            this.worldPos = worldPos;
        }
    }
    public class InputManager : MonoBehaviour
    {
        private Touch _touch;
        private RaycastHit _hit;


        public static event Action<TouchedObjInfo> ObjectTouched;


        private void Update()
        {
            CheckInput();
        }
        private void CheckInput()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                CheckDetection();
            }

        }
        private void CheckDetection()
        {
            TouchedObjInfo info = Detect();
            if (info.GameObjectType == GameObjectType.Null)
            {
                return;
            }
            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    ObjectTouched?.Invoke(info);
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    break;
                default:
                    break;
            }
        }

        private TouchedObjInfo Detect()
        {
            if (RayCheck() == true)
            {
                if (_hit.collider.TryGetComponent(out ColliderTypeDetect collideType))
                {
                    return new TouchedObjInfo(collideType.Type, collideType.Root, _hit.point);
                }
            }

            return new TouchedObjInfo();
        }
        private bool RayCheck()
        {
            Ray ray = Camera.main.ScreenPointToRay(_touch.position);
            if (Physics.Raycast(ray, out _hit))
            {
                return true;
            }

            return false;
        }
    }
}

