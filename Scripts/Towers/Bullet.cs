using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject damagePopUp;

    [Header("Attributes")]
    public float speed = 70f;
    public void Chase(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
         
        if(dir.magnitude <= distanceThisFrame)
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
        damagePopUpGO.GetComponent<TextMesh>().text = Turret.StandartTurretDamage.ToString();

        Damage(target);
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(Turret.StandartTurretDamage);
        }
    }
}
