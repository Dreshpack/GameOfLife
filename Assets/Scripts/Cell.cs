using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool isAlive = false;
    private bool ableTochangeCell;
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField] private Sprite[] SpriteList;
    [SerializeField]private int neighborCount = 0;
    
    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
    }
    
    public int NeighborCount
    {
        get
        {
            return neighborCount;
        }
        set
        {
            if(value >= 0)
            {
                neighborCount = value;
            }
        }
    }

    public void unableToChangeCell()
    {
        ableTochangeCell = false;
    }

    public void SetAlive(bool AliveSetter)
    {
        isAlive = AliveSetter;
        if(isAlive)
        {
            sprite.sprite = SpriteList[1];
        }
        else
        {
            sprite.sprite = SpriteList[0];
        }
    }

    void OnMouseDown()
    {
        if(ableTochangeCell)
        {
        Debug.Log("change life");
        SetAlive(!IsAlive);
        }
    }

    private void Awake()
    {
        ableTochangeCell = true;
        sprite = GetComponent<SpriteRenderer>();
    }
}
