public class CollidedWithAnyPieceTransition : CollisionBasedTransition
{
    protected override void OnPieceCollidedWithPiece(Piece otherPiece)
    {
        IsNeeded = true;
    }
}
