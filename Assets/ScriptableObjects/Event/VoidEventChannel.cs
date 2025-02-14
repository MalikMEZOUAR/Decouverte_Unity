using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "VoidEventChannel", menuName = "Scriptable Objects/Event/VoidEventChannel")]
public class VoidEventChannel : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void Raise(){
        if (OnEventRaised != null){
            OnEventRaised.Invoke();
        }
    }
}
