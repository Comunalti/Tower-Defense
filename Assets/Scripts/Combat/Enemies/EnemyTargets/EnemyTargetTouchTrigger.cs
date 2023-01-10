namespace Combat.Enemies
{
    public class EnemyTargetTouchTrigger : Trigger2DHandler<EnemyTarget>
    {
        // public class EnemyTargetToucher : MonoBehaviour
        // {
        //     [SerializeField] private List<EnemyTarget> enemyTargetsTouched;
        //     public UnityEvent<EnemyTarget> EnemyTargetAddedEvent;
        //     public UnityEvent<EnemyTarget> EnemyTargetRemovedEvent;
        //         
        //     private void OnTriggerEnter2D(Collider2D other)
        //     {
        //         var enemyTarget = other.GetComponentInChildren<EnemyTarget>();
        //         if (enemyTarget!=null)
        //         {
        //             enemyTargetsTouched.Add(enemyTarget);
        //             EnemyTargetAddedEvent.Invoke(enemyTarget);
        //         }
        //     }
        //
        //     private void OnTriggerExit2D(Collider2D other)
        //     {
        //         var enemyTarget = other.GetComponentInChildren<EnemyTarget>();
        //         if (enemyTarget!=null)
        //         {
        //             enemyTargetsTouched.Remove(enemyTarget);
        //             EnemyTargetRemovedEvent.Invoke(enemyTarget);
        //         }
        //     }
        // }
    }
}