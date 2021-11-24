using UnityEngine;
using System.Collections;
public abstract class Damage : MonoBehaviour
{
    public delegate void d_Damage(float pt); // Передача урона флоат
    public abstract event d_Damage e_Damage; // передача урона флоат


   

    

    protected abstract void OnTriggerEnter2D(Collider2D collision);
    protected abstract void OnTriggerExit2D(Collider2D collision);
    protected abstract IEnumerator DamageTime(float a);

    protected abstract void CallDamage();
   
}


