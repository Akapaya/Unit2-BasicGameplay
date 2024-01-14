using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _yLimitPositivePosition = 30;
    private float _yLimitNegativePosition = -8;

    private void Update()
    {
        if(transform.position.y > _yLimitPositivePosition)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            if (transform.position.y < _yLimitNegativePosition)
            {
                this.gameObject.SetActive(false);
                GameOverManager.GameOverHandle?.Invoke();
            }
        }
    }
}