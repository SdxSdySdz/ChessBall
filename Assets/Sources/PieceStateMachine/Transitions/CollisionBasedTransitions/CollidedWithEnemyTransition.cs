public class CollidedWithEnemyTransition : CollisionBasedTransition
{
    protected override void OnPieceCollidedWithPiece(Piece otherPiece)
    {
        IsNeeded = Piece.IsEnemy(otherPiece);
    }
}
