using UnityEngine;
interface IMove
{
    public void Move();
}
public interface IDamage // Передача урона 
{
    public void ActionIDamage();
}

//public interface IHealth // Здоровье.
//{
//    delegate void d_Health(float HP); // Передача хп
//    event d_Health e_Health;
//    delegate void d_Dead();
//    event d_Dead e_Dead;// ивент на смерть
//    public void StartSceneHealth(); // В начале игры назначаю здоровье    
//}

 

