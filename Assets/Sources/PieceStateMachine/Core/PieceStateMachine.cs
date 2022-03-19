using UnityEngine;

public class PieceStateMachine : MonoBehaviour
{
    [SerializeField] private Piece _piece;
    [SerializeField] private State _firstState;

    private Board _board;
    private State _currentState;

    private void Awake()
    {
        _board = FindObjectOfType<Board>();
    }

    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();
        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State state)
    {
        _currentState = state;

        if (_currentState != null)
            _currentState.Enter(_piece, _board);
    }

    private void Transit(State state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter(_piece, _board);
    }
}
