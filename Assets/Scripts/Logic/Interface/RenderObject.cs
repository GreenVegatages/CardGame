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
            if (LogicObj == null) return;
            transform.position = Vector3.Lerp(transform.position, LogicObj.LogicPosition.vec3,BattleWorld.DeltaTime);
      }

      public virtual void OnRelease()
      {
            GameObject.Destroy(gameObject);
      }
}