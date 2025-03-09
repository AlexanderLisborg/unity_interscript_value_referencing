using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Event based solution for passing valus to animators. For each float and bool 
//  value in the attached ObservableValueCollection, attaches event handlers that
/// pass those values to a set of animators. ALL values in the ObservableValueCollection
/// gets passed to ALL animators. If corresponding values does not exist in an Animator
/// instance, the execution continues without exception and nothing is passed.
/// </summary>
public class AnimatorHandler : MonoBehaviour
{
    /// <summary>
    /// The Animator(s) to pass values to. Prints debug message if null. 
    /// </summary>
    [SerializeField] private List<Animator> _animators;
    /// <summary>
    /// The ObservableValueCollection to observe. Prints debug message if null.
    /// </summary>
    [SerializeField] private ObservableValueCollection _observableValueCollection;
    /// <summary>
    /// Tries to attach handlers to all events in the ObservableValueCollection.
    /// ObservableValueCollection is initialized at Awake(), the attachment
    /// of event handlers is done at Start() since Start() runs after Awake().
    /// </summary>
    void Start()
    {
        if(_animators == null || _observableValueCollection == null)
        {
            if(_animators == null)                  {Debug.Log("animators list is null!");}
            if(_observableValueCollection == null)  {Debug.Log("observable value collection reference is null!");}
            Debug.Log("Animations loaded incorrectly. Animations for GameObject " + gameObject.GetInstanceID() + " will not run correctly.");
        }
        else if(_observableValueCollection != null)
        {   
            foreach(KeyValuePair<string,ObservableValue<float>> kvp in _observableValueCollection.ObservableFloats)
            {
                kvp.Value.UpdateValue += HandleFloatUpdateEvent;
            }
            foreach(KeyValuePair<string,ObservableValue<bool>> kvp in _observableValueCollection.ObservableBools)
            {
                kvp.Value.UpdateValue += HandleBoolUpdateEvent;
            }  
        } 
    }
    
    // Handler for float value updates.
    private void HandleFloatUpdateEvent(string name, float f)
    {
        foreach(Animator a in _animators)
        {
            a.SetFloat(name, f); 
        }
    }
    // Handler for bool value updates
    private void HandleBoolUpdateEvent(string name, bool b)
    {
        foreach(Animator a in _animators)
        {
            a.SetBool(name, b);
        }
    }

}
