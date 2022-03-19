using UnityEngine;

public class ReachedTargetFieldTransition : Transition
{
    [SerializeField] private MovingState _movingState;

    protected override void OnEnable()
    {
        _movingState.Finished += OnMovingStateFinished;
    }

    protected override void OnDisable()
    {
        _movingState.Finished -= OnMovingStateFinished;
    }

    private void OnMovingStateFinished()
    {
        IsNeeded = true;
    }
}
