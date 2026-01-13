using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public void SetEffectPosition(VInt3 logicPosition)
    {
        transform.position =logicPosition.vec3;
        Destroy(gameObject,3f);
    }
}
