using UnityEngine;
using UnityEngine.Audio;

public class Turret : MonoBehaviour
{
    private Enemy targetEnemy;
    private float fireCountDown = 0f;

    public static float StandartTurretFireRate = 1, StandartTurretDamage = 20, StandartTurretRange = 10;

    [Header("Unity shtuki")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public AudioSource bulletShot;
    private Transform target;
    public Transform partToRotate;
    public Transform bulletPoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void Update()
    {
        
        if (target == null)
            return;

        LockOnTarget();

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / StandartTurretFireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= StandartTurretRange)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*5f).eulerAngles; //lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot()
    {
       GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
       Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bulletShot.Play();
            bullet.Chase(target);
        }
    }
    public static void ResetAtributes()
    {
        StandartTurretDamage = 20;
        StandartTurretFireRate = 1;
        StandartTurretRange = 10;
    }
}
