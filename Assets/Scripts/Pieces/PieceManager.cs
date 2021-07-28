using System;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{

    public GameObject mPiecePrefab;

    private List<PieceBase> mWhitePieces = null;
    private List<PieceBase> mBlackPieces = null;


    private string[] mPieceOrder = new string[16]
    {
        "P","P","P","P","P","P","P","P",
        "R","KN","B","K","Q","B","KN","R"
    };

    private Dictionary<string, Type> mPieceLibrary = new Dictionary<string, Type>()
    {
        {"P", typeof(Pawn)},
        {"R", typeof(Rook)},
        {"KN", typeof(Knight)},
        {"B", typeof(Bishop)},
        {"K", typeof(King)},
        {"Q", typeof(Queen)}
    };

    public void Setup(Board board)
    {
        mWhitePieces = CreatePieces(Color.white, new Color32(255, 255, 255, 255), board);
        mBlackPieces = CreatePieces(Color.black, new Color32(1, 1, 1, 255), board);

        PlacePieces(1, 0, mWhitePieces, board);
        PlacePieces(6, 7, mBlackPieces, board);

    }

    private List<PieceBase> CreatePieces(Color teamColor, Color32 spriteColor, Board board)
    {
        var newPieces = new List<PieceBase>();

        for (int i = 0; i < mPieceOrder.Length; i++)
        {
            GameObject newPieceObject = Instantiate(mPiecePrefab);
            newPieceObject.transform.SetParent(transform);

            newPieceObject.transform.localScale = new Vector3(1, 1, 1);
            newPieceObject.transform.localRotation = Quaternion.identity;

            string key = mPieceOrder[i];
            Type pieceType = mPieceLibrary[key];

            PieceBase newPiece = (PieceBase)newPieceObject.AddComponent(pieceType);
            newPieces.Add(newPiece);

            newPiece.Setup(teamColor, spriteColor, this);

        }

        return newPieces;
    }
    private void PlacePieces(int pawnRow, int royaltyRow, List<PieceBase> pieces, Board board)
    {
        for (int i = 0; i < 8; i++)
        {
            pieces[i].Place(board.mAllCells[i, pawnRow]);
            pieces[i + 8].Place(board.mAllCells[i, royaltyRow]);
        }
    }
}
