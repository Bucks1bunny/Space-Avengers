using System; 
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 5;
    public float maxHealth = 100;
    public int moneyGain = 20;
    public int healthTakes;

    public HealthSlider healthBar;

    private Transform target;
    private float currentHealth;
    private int waypointIndex = 0;
    void Start()
    {
        target = Waypoints.points[0];
        transform.LookAt(target);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (GameManager.isGameOver)
            Destroy(gameObject);

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);
        if (Vector3.Distance(target.position, transform.position)<=0.2f)
        {
            GetNextWaypoint();
            transform.LookAt(target);
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
            Die();
    }
    void Die()
    {
        PlayerStats.Money += moneyGain;
        Spawner.enemyAlive--;
        Destroy(gameObject);
    }
    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1) 
        {
            Destroy(gameObject);
            Spawner.enemyAlive--;
            PlayerStats.Lives -= healthTakes;
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
   
}
