using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ManualModeGame : Game
{
    List<string> allGrids = new List<string>();
    private string CodeGrid(Cell[,] grid)
    {
        string lastGrid = "";
        foreach(Cell cells in grid)
        {
            if(cells.IsAlive)
            {
                lastGrid+="1";
            }
            else
            {
                lastGrid+="0";
            }
        }
        return lastGrid;
    }
    private bool loseCheck()
    {
        string lastGrid = CodeGrid(grid);
        if(allGrids.Count > 1)
        {
        if(allGrids.Contains(lastGrid))
        {
            Debug.Log("ebat clown");
            return true;
        }
        else
        {
            allGrids.Add(lastGrid);
        }
        }
        else
        {
            allGrids.Add(lastGrid);
        }
        return false;
    }
    private new void PlaceCells()
    {
        for(int i = 0; i < ScreenHeight; i++)
        {
            for(int j = 0; j < ScreenWidth; j++)
            {
                Cell cell = Instantiate(Resources.Load("Prefabs/Cell", typeof(Cell)), new Vector2(j,i), Quaternion.identity) as Cell;
                grid[j, i] = cell;
                grid[j, i].SetAlive(false);
            }
        }
    }

    protected override IEnumerator UpdateCorotine()
    {
        while(true)
        {
        CountNeighbors();
        PopulationController();
        if(loseCheck())
        {
            StopAllCoroutines();
        }
        yield return new WaitForSeconds(speed);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            foreach(Cell cells in grid)
            {
                cells.unableToChangeCell();
            }
            StartCoroutine(UpdateCorotine());
        }
    }

    private void Start()
    {
        PlaceCells();
    }
}
