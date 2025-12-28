using UnityEngine;

public class ResManager : Singleton<ResManager>
{
        /// <summary>
        /// 加载预制体
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="parent">父对象</param>
        /// <param name="resetPosition">重置位置</param>
        /// <param name="resetRotation">重置旋转</param>
        /// <param name="resetScale">重置缩放</param>
        /// <returns></returns>
        public GameObject LoadPrefab(string path, Transform parent = null,bool resetPosition = false,
                bool resetRotation = false,bool resetScale = false)
        {
                var obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(path),parent);
                if (resetPosition)
                {
                        obj.transform.localPosition = Vector3.zero;
                }

                if (resetRotation)
                {
                        obj.transform.localRotation = Quaternion.identity;
                }

                if (resetScale)
                {
                        obj.transform.localScale = Vector3.one;
                }
                
                return obj;
        }
        /// <summary>
        /// 加载预制体并通过泛型获取身上的组件
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="parent">父对象</param>
        /// <typeparam name="T">需要获取的组件</typeparam>
        /// <returns>需要获取的Component</returns>
        public T LoadPrefab<T>(string path, Transform parent = null)
        {
                var obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(path),parent);
                T t = obj.GetComponent<T>();
                return t;
        }
        
        /// <summary>
        /// 加载资源
        /// </summary>
        /// <param name="path">路径</param>
        /// <typeparam name="T">需要获取的资源类型</typeparam>
        /// <returns></returns>
        public T LoadAsset<T>(string path) where T : Object
        {
                return Resources.Load<T>(path);
        }
}