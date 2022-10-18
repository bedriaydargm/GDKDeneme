using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float shootDelay;
    [SerializeField] private GameObject bulletPrefab;

    public async void Shoot()
    {
        while (GameManager.instance.isGamePlaying)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            await System.Threading.Tasks.Task.Delay((int) (shootDelay * 100));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle")) return;

        GameManager.instance.EndGame();
    }
}
