using UnityEngine;

public abstract class ReleasedTransition : Transition
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Field field))
                {
                    OnPieceReleased(field);
                }
            }
        }
    }

    protected abstract void OnPieceReleased(Field field);
}
