using UnityEngine;

public class XaxisUpCollider : MonoBehaviour, ISwapable
{
    public Vector2 GetRespwanPosition(Vector2 _position)
    {
        Vector2 respwanPosition = _position;

        respwanPosition.x = -1f * (respwanPosition.x - 2.5f);
        respwanPosition.y = 1f * (respwanPosition.y);

        return respwanPosition;
    }
}
