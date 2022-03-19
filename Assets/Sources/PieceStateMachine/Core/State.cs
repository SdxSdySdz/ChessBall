using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Piece _piece;
    private Board _board;

    protected Piece Piece => _piece;
    protected Board Board => _board;

    private void Awake()
    {
        enabled = false;
        OnAwake();
    }

    public void Enter(Piece piece, Board board)
    {
        Debug.LogError($"{this.GetType().Name} Enter");

        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(piece);
            }
        }

        _piece = piece;
        _board = board;
        OnEnter();
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }

        _piece = null;
        _board = null;
        OnExit();
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.IsNeeded)
                return transition.TargetState;
        }

        return null;
    }

    protected virtual void OnAwake() { }

    protected virtual void OnEnter() { }

    protected virtual void OnExit() { }
}
