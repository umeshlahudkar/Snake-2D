using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaxisUpCollider : MonoBehaviour, ISwapable
{
    public Vector2 GetRespwanPosition(Vector2 _position)
    {
        Vector2 respwanPosition = _position;

        respwanPosition.x = 1f * (respwanPosition.x);
        respwanPosition.y = -1f * (respwanPosition.y - 2.5f);

        return respwanPosition;
    }
}
