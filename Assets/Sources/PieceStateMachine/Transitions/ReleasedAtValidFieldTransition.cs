using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleasedAtValidFieldTransition : ReleasedTransition
{
    protected override void OnPieceReleased(Field field)
    {
        IsNeeded = field.IsHighlighted;
    }
}
