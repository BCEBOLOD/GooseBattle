using UnityEngine;
public abstract class Health : MonoBehaviour
{
    //[SerializeField] private float _base_Health;
    //public float CurrentHealth { get; protected set; }    

    public delegate void d_Dead();
    public abstract event d_Dead e_Dead;// ивент на смерть

    //protected virtual void Start()
    //{
    //    StartSceneHealth();

    //}
    //public void StartSceneHealth()
    //{
    //    CurrentHealth = _base_Health;

    //}
   //protected abstract void OnChangedCurrentHealth(float a);     //Отнимание хп (Обработчик урона)


}
