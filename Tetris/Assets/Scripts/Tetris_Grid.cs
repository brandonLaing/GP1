using Assets.Scripts.GameClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris_Grid : MonoBehaviour
{
    public int gridWidth = 10;
    public int gridHeight = 20;

    private TetrisGameGrid myGrid;     // null by default

    public GameObject whiteBlock;
    public GameObject redBlock;
    public GameObject orangeBlock;
    public GameObject yellowBlock;
    public GameObject greenBlock;
    public GameObject blueBlock;
    public GameObject purpleBlock;

    // Use this for initialization
    void Start()
    {
        myGrid = new TetrisGameGrid(gridWidth, gridHeight);

        myGrid.gridSpaces[0, 0] = new Block(0, 0, BlockColor.Green);
    }

    // Update is called once per frame
    void Update()
    {
        //Draw a square in the appropriate location
        //for all occupied blocks in myGrid

        for(int x = 0; x < gridWidth; x++)
        {
           
            for(int y = 0; y < gridHeight; y++)
            {
                if (myGrid.gridSpaces[x, y] == null)
                {
                    if(myGrid.gridSpaces[x,y].color == BlockColor.Green)
                    {
                        GameObject newGreenBlock = GameObject.Instantiate(greenBlock);
                    }
                }

                // if the space is null

                    // if myGrid color == green

                        // make the green object








                //Prefab instantiation example
                //
                //if (myGrid.gridSpaces[x, y] != null)
                //{
                //   if (myGrid.gridSpaces[x, y].color == BlockColor.Green)
                //    {
                //        GameObject newGreenBlock = GameObject.Instantiate(greenBlock);
                //    }
                //}
            }
        }
    }
}
