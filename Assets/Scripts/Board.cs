using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{

    public GameObject mCellPrefab;
    [HideInInspector]
    public Cell[,] mAllCells = new Cell[8, 8];
    bool even = false;

    public void Create()
    {
        GenerateCheckboard();
        CheckboardColor();
    }
    void CheckboardColor()
    {

        for (int y = 0; y < 8; y++)
        {
            if (y % 2 == 0)
            {
                ColorRowFromFirstBlack(y);
            }
            else
            {
                ColorRowFromFirstWhite(y);
            }
        }
    }
    void ColorRowFromFirstWhite(int positionY)
    {
        for (int x = 0; x < 8; x++)
        {
            if (x % 2 == 0)
            {
                mAllCells[x, positionY].GetComponent<Image>().color = new Color32(186, 177, 150, 255);
            }
        }
    }

    void ColorRowFromFirstBlack(int positionY)
    {
        for (int x = 0; x < 8; x++)
        {
            if (x % 2 != 0)
            {
                mAllCells[x, positionY].GetComponent<Image>().color = new Color32(186, 177, 150, 255);
            }
        }
    }


    private void GenerateCheckboard()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 100) + 50, (y * 100) + 50);

                mAllCells[x, y] = newCell.GetComponent<Cell>();
                mAllCells[x, y].Setup(new Vector2Int(x, y), this);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
