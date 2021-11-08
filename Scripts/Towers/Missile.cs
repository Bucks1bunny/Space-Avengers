  using UnityEngine;

public class Missile : MonoBehaviour
{
    private Transform target;
    public GameObject damagePopUp;

    [Header("Attributes")]
    public float speed = 30f;
    public float explosionRadius = 7f;
    public void Chase(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);   
    }
   
    void HitTarget()
    {
        GameObject damagePopUpGO = Instantiate(damagePopUp, gameObject.transform.position, Quaternion.identity);
        damagePopUpGO.GetComponent<TextMesh>().text = Launcher.MissileLauncherDamage.ToString();

        Explosion();
        Destroy(gameObject);
    }
    void Explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider col in colliders)
        {
            if (col.tag == "Enemy")
                Damage(col.transform);
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(Launcher.MissileLauncherDamage);
        }
    }
}

