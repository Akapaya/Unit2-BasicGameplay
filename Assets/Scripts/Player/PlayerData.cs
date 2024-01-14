using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int AmountBullets;
    public GameObject BulletPrefab;
    public Queue<GameObject> Bullets = new();
    public float DelayToShoot = 2f;
    public bool CanShoot = true;

    public float SpeedMovement = 10f;

    private void Start()
    {
        CreateAmmoPool();
    }

    #region AmmoPoolMethod
    public void CreateAmmoPool()
    {
        for (int i = 0; i < AmountBullets; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            Bullets.Enqueue(bullet);
        }
    }

    [ContextMenu("Clear")]
    public void ClearAmmoPool()
    {
        for(int i = 0;i < AmountBullets; i++)
        {
            Destroy(Bullets.Dequeue());
        }
    }

    public GameObject GetBulletObject(Vector3 position)
    {
        GameObject bullet = Bullets.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = position;
        Bullets.Enqueue(bullet);
        return bullet;
    }
    #endregion

    #region ShootMethod
    public void Reload()
    {
        StartCoroutine(EnableShootAfterDelay());
    }

    private IEnumerator EnableShootAfterDelay()
    {
        yield return new WaitForSeconds(DelayToShoot);
        CanShoot = true;
    }
    #endregion
}