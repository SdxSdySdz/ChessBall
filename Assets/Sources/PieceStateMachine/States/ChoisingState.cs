using UnityEngine;

public class ChoisingState : State
{
    [SerializeField] private GameObject _pieceModel;
    [SerializeField] private PhantomSpawner _phantomSpawner;

    private GameObject _staticPhantom;
    private GameObject _moveablePhantom;

    private bool _arePhantomsSpawned => _staticPhantom != null && _moveablePhantom != null;

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

      
        Vector3? nearestPoint = null;
        float minDistance = float.MaxValue;

        foreach (var hit in hits)
        {
            if (hit.collider.TryGetComponent(out Field field))
            {
                if (hit.distance < minDistance)
                {
                    nearestPoint = hit.point;
                    minDistance = hit.distance;
                }
            }
        }

        if (nearestPoint != null)
            _moveablePhantom.transform.position = nearestPoint.Value;
    }

    protected override void OnEnter()
    {
        if (_arePhantomsSpawned == false)
        {
            _staticPhantom = _phantomSpawner.SpawnPhantom(_pieceModel);
            _moveablePhantom = _phantomSpawner.SpawnPhantom(_pieceModel);
        }

        _staticPhantom.transform.position = Piece.transform.position;
        _moveablePhantom.transform.position = Piece.transform.position;

        ShowPhantoms();
        _pieceModel.SetActive(false);

        foreach (var field in Board.GetPossibleFields(Piece))
        {
            field.Highlight();
        }
    }

    protected override void OnExit()
    {
        HidePhantoms();
        _pieceModel.SetActive(true);
    }

    private void ShowPhantoms()
    {
        ChangePhantomsVisibility(true);
    }

    private void HidePhantoms()
    {
        ChangePhantomsVisibility(false);
    }

    private void ChangePhantomsVisibility(bool areVisible)
    {
        _staticPhantom.SetActive(areVisible);
        _moveablePhantom.SetActive(areVisible);
    }
}
