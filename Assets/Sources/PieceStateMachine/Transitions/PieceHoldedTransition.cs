using UnityEngine;

public class PieceHoldedTransition : Transition
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Piece piece))
                {
                    IsNeeded = Piece == piece;
                }
                else if (hit.collider.TryGetComponent(out Field field))
                {
                    IsNeeded = field.PlacedPiece == Piece;
                }
            }
        }
    }
}
