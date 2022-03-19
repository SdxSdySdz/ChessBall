using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private GameObject _model;

    private Piece _placedPiece;

    public Piece PlacedPiece => _placedPiece;
    public bool IsHighlighted { get; private set; }

    public void Place(Piece piece)
    {
        _placedPiece = piece;

        _placedPiece.transform.position = transform.position;
    }

    public void UnPlace()
    {
        _placedPiece = null;
    }

    public void Highlight()
    {
        IsHighlighted = true;
        _model.GetComponent<Renderer>().material.color = Color.white;
    }

    public void UnHighlight()
    {
        IsHighlighted = false;
    }
}
