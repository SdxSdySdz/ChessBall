public class ReleasedAtInvalidFieldTransition : ReleasedTransition
{
    protected override void OnPieceReleased(Field field)
    {
        IsNeeded = field.IsHighlighted == false;
    }
}
