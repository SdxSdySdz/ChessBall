public class IdleState : State
{
    protected override void OnEnter()
    {
        Board.PlaceToNearestField(Piece);
    }
}
