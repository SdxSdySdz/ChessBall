using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Field _whiteFieldPrefab;
    [SerializeField] private Field _blackFieldPrefab;

    [SerializeField] private Vector2Int _size;

    private Field[,] _grid;

    private IEnumerable<Field> Fields => GetFields();

    public int RowsCount => _size.x;
    public int ColumnsCount => _size.y;

    private void Awake()
    {
        _grid = new Field[RowsCount, ColumnsCount];
        InstantiateFields();
    }

    public List<Field> GetPossibleFields(Piece piece)
    {
        if (TryGerBoardPosition(piece, out Vector2Int boardPosition) == false)
            return new List<Field>();

        List<Field> possibleFields = new List<Field>();
        foreach (var offset in piece.GetOffsets(Mathf.Max(RowsCount, ColumnsCount)))
        {
            Vector2Int possibleMove = boardPosition + offset;
            if (IsOnBoard(possibleMove))
                possibleFields.Add(_grid[possibleMove.x, possibleMove.y]);
        }

        return possibleFields;
    }

    public void PlaceToNearestField(Piece piece)
    {
        Field nearestField = _grid[0, 0];
        float minDistance = Vector3.Distance(piece.transform.position, nearestField.transform.position);

        foreach (var field in Fields)
        {
            if (field.PlacedPiece == piece)
                return;

            float distance = Vector3.Distance(piece.transform.position, field.transform.position); ;
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestField = field;
            }
        }

        nearestField.Place(piece);
    }

    public bool IsPlaced(Piece piece)
    {
        return TryGetField(piece, out _);
    }

    public bool IsOnBoard(Vector2Int boardPosition)
    {
        return IsOnBoard(boardPosition.x, boardPosition.y);
    }

    public bool IsOnBoard(int row, int column)
    {
        return 0 <= row && row < RowsCount && 
            0 <= column && column < ColumnsCount;
    }

    private bool TryGetField(Piece piece, out Field fieldUnderPiece)
    {
        foreach (var field in Fields)
        {
            if (field.PlacedPiece == piece)
            {
                fieldUnderPiece = field;
                return true;
            }
        }

        fieldUnderPiece = null;
        return false;
    }

    private bool TryGerBoardPosition(Piece piece, out Vector2Int boardPosition)
    {
        for (int row = 0; row < RowsCount; row++)
        {
            for (int column = 0; column < ColumnsCount; column++)
            {
                if (_grid[row, column].PlacedPiece == piece)
                {
                    boardPosition = new Vector2Int(row, column);
                    return true;
                }
            }
        }

        boardPosition = new Vector2Int(-1, -1);
        return false;
    }

    private IEnumerable<Field> GetFields()
    {
        for (int row = 0; row < RowsCount; row++)
        {
            for (int column = 0; column < ColumnsCount; column++)
            {
                yield return _grid[row, column];
            }
        }
    }

    private void InstantiateFields()
    {
        for (int row = 0; row < RowsCount; row++)
        {
            for (int column = 0; column < ColumnsCount; column++)
            {
                Field fieldPrefab = (row + column) % 2 == 0 ? _whiteFieldPrefab : _blackFieldPrefab;
                Field instance = Instantiate(fieldPrefab, transform);
                instance.transform.localPosition = new Vector3(row, 0, column);

                _grid[row, column] = instance;
            }
        }
    }
}
