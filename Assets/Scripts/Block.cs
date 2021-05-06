using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BlockType
    {
        Destructible,
        Indestructible,
        Traversable
    }

    public BlockType blockType = BlockType.Destructible;
    [Range(1, 6)]
    public uint initialLives = 4;

    public bool isTraversable
    {
        get
        {
            return blockType == BlockType.Traversable;
        }
    }

    public bool isDestruible
    {
        get
        {
            return blockType == BlockType.Destructible;
        }
    }

    public bool isIndestructible
    {
        get
        {
            return blockType == BlockType.Indestructible;
        }
    }

    private uint _lifes;
    public uint life
    {
        get
        {
            return _lifes;
        }
        set
        {
            _lifes = value;
            if (_lifes == 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        _lifes = initialLives;

        if (isTraversable)
        {
            foreach (Collider c in transform.GetComponentsInChildren<Collider>())
            {
                c.enabled = false;
            }
        }
    }

}
