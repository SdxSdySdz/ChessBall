public class CollidedWithFriendTransition : CollisionBasedTransition
{
    protected override void OnPieceCollidedWithPiece(Piece otherPiece)
    {
        IsNeeded = Piece.IsEnemy(otherPiece) == false;
    }
}
