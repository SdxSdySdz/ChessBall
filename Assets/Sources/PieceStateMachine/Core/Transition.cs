using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    private Piece _piece;

    protected Piece Piece => _piece;

    public State TargetState => _targetState;
    public bool IsNeeded { get; protected set; }

    private void Awake()
    {
        enabled = false;
    }

    protected virtual void OnEnable()
    {
        IsNeeded = false;
    }

    protected virtual void OnDisable() { }

    public void Init(Piece piece)
    {
        _piece = piece;
        OnInit();
    }

    protected virtual void OnInit() { }
}

