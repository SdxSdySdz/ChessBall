using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece
{
    public override List<Vector2Int> GetOffsets(int maxDistance)
    {
        List<Vector2Int> offsets = new List<Vector2Int>();

        foreach (var offset in new[] { 1, 2 })
        {
            foreach (var rowSign in new[] { -1, 1})
            {
                foreach (var columnSign in new[] { -1, 1 })
                {
                    int rowOffset = rowSign * offset;
                    int columnOffset = columnSign * (3 - offset);

                    if (rowOffset <= maxDistance && columnOffset <= maxDistance)
                        offsets.Add(new Vector2Int(rowOffset, columnOffset));
                }
            }
        }

        return offsets;
    }
}
