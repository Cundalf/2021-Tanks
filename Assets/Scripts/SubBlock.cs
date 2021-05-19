using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBlock : MonoBehaviour
{
    private Block parentBlock;

    public void damage()
    {
        if (parentBlock.isIndestructible)
            return;

        if (parentBlock.life > 0)
        {
            parentBlock.life -= 1;
        }

        GameObject.Destroy(gameObject);
    }

    void Start()
    {
        parentBlock = transform.parent.GetComponent<Block>();
    }
}
