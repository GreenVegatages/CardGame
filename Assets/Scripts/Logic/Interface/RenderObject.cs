using System;
using UnityEngine;

public class RenderObject : MonoBehaviour
{
      public LogicObject LogicObj { get;protected set; }
      
      public virtual void SetLogicObject(LogicObject logicObject)
      {
            this.LogicObj = logicObject;
      }

      public virtual void Update()
      {
            
      }

      public virtual void OnRelease()
      {
            GameObject.Destroy(gameObject);
      }
}