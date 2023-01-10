using System.Collections;
using UnityEngine;

namespace Combat.Weapons
{
    public class SimpleTimerLifeTimeBulletDestroyer : MonoBehaviour
    {
        [SerializeField] private float time;
        [SerializeField] private GameObject root;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(time);
            Destroy(root);
        }
    }
}