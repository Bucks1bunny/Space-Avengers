using UnityEngine;
using UnityEngine.Audio;

public class Launcher : MonoBehaviour
{
    private float fireCountDown = 0f;
    public static float MissileLauncherDamage = 50f, MissileLauncherFireRate = 0.5f, MissileLauncherRange = 15f;

    [Header("Unity")]
    private Transform target;
    public Transform partToRotate;
    public GameObject missilePrefab;
    public AudioSource missileAudio;
    public Transform missilePoint;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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
        if (nearestEnemy != null && shortestDistance <= MissileLauncherRange)
            target = nearestEnemy.transform;
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*5f).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / MissileLauncherFireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject missileGO = (GameObject)Instantiate(missilePrefab, missilePoint.position, missilePoint.rotation);
        Missile missile = missileGO.GetComponent<Missile>();

        if (missile != null)
        {
            missileAudio.Play();
            missile.Chase(target);
        }
    }
    public static void ResetAtributes()
    {
        MissileLauncherDamage = 50;
        MissileLauncherFireRate = 0.5f;
        MissileLauncherRange = 15f;
    }
}
