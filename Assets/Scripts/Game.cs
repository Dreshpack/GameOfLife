using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    protected static int ScreenWidth = 120;   //1920px
    protected static int ScreenHeight = 67;   //1080px
    [SerializeField] protected float speed = 0.1f;

    protected Cell[,] grid = new Cell[ScreenWidth, ScreenHeight];

    protected void PlaceCells()
    {
        for(int i = 0; i < ScreenHeight; i++)
        {
            for(int j = 0; j < ScreenWidth; j++)
            {
                Cell cell = Instantiate(Resources.Load("Prefabs/Cell", typeof(Cell)), new Vector2(j,i), Quaternion.identity) as Cell;
                grid[j, i] = cell;
                grid[j, i].SetAlive(RandomAliveCells());
            }
        }
    }

    private bool RandomAliveCells()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if(rand > 75)
        {
            return true;
        }
        return false;
    }

    protected void CountNeighbors()
    {
        for(int i = 0; i < ScreenHeight; i++)
        {
            for(int j = 0; j < ScreenWidth; j++)
            {
                int neighborsNumber = 0;
                if(i+1 < ScreenHeight)//N
                {
                    if(grid[j,i+1].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                if(j+1 < ScreenWidth)//E
                {
                    if(grid[j+1,i].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                if(i-1>=0)//S
                {
                    if(grid[j, i-1].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                if(j-1 >= 0)//W
                {
                    if(grid[j-1,i].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                if(i + 1 < ScreenHeight && j + 1 < ScreenWidth)//NE
                {
                    if(grid[j+1, i+1].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                if(i + 1 < ScreenHeight && j - 1 >= 0)//NW
                {
                    if(grid[j-1, i+1].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                if(i - 1 >= 0 && j - 1 >= 0)//SW
                {
                    if(grid[j-1, i-1].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                if(i - 1 >= 0 && j + 1 < ScreenWidth)//SE
                {
                    if(grid[j+1, i-1].IsAlive)
                    {
                        neighborsNumber++;
                    }
                }
                grid[j,i].NeighborCount = neighborsNumber;
            }
        }
    }

    protected void PopulationController()
    {
        for(int i = 0; i < ScreenHeight; i++)
        {
            for(int j = 0; j < ScreenWidth; j++)
            {
                if(grid[j,i].IsAlive)
                {
                    if(grid[j,i].NeighborCount < 2 || grid[j,i].NeighborCount > 3)
                    {
                        grid[j,i].SetAlive(false);
                    }
                }
                else
                {
                    if(grid[j,i].NeighborCount == 3)
                    {
                        grid[j,i].SetAlive(true);
                    }
                }
            }
        }
    }

    protected virtual IEnumerator UpdateCorotine()
    {
        while(true)
        {
        CountNeighbors();
        PopulationController();
        yield return new WaitForSeconds(speed);
        }
    }
    
    private void Start()
    {
        PlaceCells();
        StartCoroutine(UpdateCorotine());
    }   
}
