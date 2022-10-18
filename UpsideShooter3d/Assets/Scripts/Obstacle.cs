using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int health;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider collider;

    public void Init(int health, Vector3 force)
    {
        this.health = health;
        meshRenderer.sharedMaterial = GameManager.instance.obstacleData.levels[health - 1].material;
        transform.localScale = GameManager.instance.obstacleData.levels[health - 1].size * Vector3.one;
        rb.velocity = Vector3.zero;
        rb.AddForce(force + .25f * Vector3.up, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet")) return;
        other.GetComponent<Bullet>().Effect();
        Split();
    }

    private void Split()
    {
        meshRenderer.enabled = false;
        collider.enabled = false;

        if (health > 1)
        {
            Vector3 offset = new Vector3(transform.localScale.x / 2f, 0, 0);

            Obstacle obstacle1 = Instantiate(GameManager.instance.obstaclePrefab, transform.position + offset, Quaternion.identity).GetComponent<Obstacle>();
            obstacle1.Init(health-1, offset);

            Obstacle obstacle2 = Instantiate(GameManager.instance.obstaclePrefab, transform.position - offset, Quaternion.identity).GetComponent<Obstacle>();
            obstacle2.Init(health-1, -offset);
        }

        GameManager.instance.AddScore(1);
        GameManager.instance.RemoveObstacle(this);
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        GameManager.instance.AddObstacle(this);
    }
}
