using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBlock : MonoBehaviour
{
    private Block parentBlock;

    private void OnTriggerEnter(Collider other)
    {
        if (parentBlock.isDestruible && other.CompareTag("Bullet"))
        {
            if (parentBlock.life > 0)
            {
                parentBlock.life -= 1;
            }

            GameObject.Destroy(gameObject);
        }
    }

    void Start()
    {
        parentBlock = transform.parent.GetComponent<Block>();
    }
}
