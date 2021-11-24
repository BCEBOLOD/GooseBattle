using TMPro;
using UnityEngine;

public abstract class ChangedBar : MonoBehaviour
{
    
    [SerializeField] protected TextMeshProUGUI _dataText;

    protected abstract void OnEnable();

    protected abstract void OnDisable();
    

  //  protected abstract void OnChangedStateUIBar(float Data);
    
}
