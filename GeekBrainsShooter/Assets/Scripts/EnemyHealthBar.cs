public class EnemyHealthBar : HealthBarController
{
    public override void GetDamage(float damage){
        base.GetDamage(damage);
        if (_health <= 0) {
            Destroy(gameObject);
        }
    }
}
