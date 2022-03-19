using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PieceStateMachine))]
public abstract class Piece : MonoBehaviour
{
    public event UnityAction<Piece> CollidedWithPiece;

    public bool IsEnemy(Piece otherPiece)
    {
        return false;
    }

    public abstract List<Vector2Int> GetOffsets(int maxDistance);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Piece piece))
        {
            CollidedWithPiece?.Invoke(piece);
        }
    }
}

