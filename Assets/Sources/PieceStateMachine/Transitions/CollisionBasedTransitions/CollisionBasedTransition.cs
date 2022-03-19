public abstract class CollisionBasedTransition : Transition
{
    protected override void OnEnable()
    {
        base.OnEnable();
        if (Piece != null)
            Piece.CollidedWithPiece += OnPieceCollidedWithPiece;
    }

    protected override void OnDisable()
    {
        base.OnEnable();
        if (Piece != null)
            Piece.CollidedWithPiece -= OnPieceCollidedWithPiece;
    }

    protected abstract void OnPieceCollidedWithPiece(Piece otherPiece);
}
