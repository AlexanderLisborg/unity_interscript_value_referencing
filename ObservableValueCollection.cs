using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Collection of observable values. Used for passing values between Unity scripts in an
/// event based, modular manner. Attach to a gameobject to handle variables "belonging" to
/// that gameobject. Names are used as identifiers and should match corresponding
/// names in other scripts.
/// </summary>
public class ObservableValueCollection : MonoBehaviour
{
    // Lists of value names are used to configure the value collection from within Unity.
    // for each name specified, an ObservableValue is instantiated and added to the
    // Dictionary corresponding to its type.
    [SerializeField] private List<string> _intNames;
    [SerializeField] private List<string> _floatNames;
    [SerializeField] private List<string> _boolNames;
    [SerializeField] private List<string> _vector2Names;
    /// <summary>
    /// Dictionary of observable ints. Use ObservableInts[name] to get a value. Don't
    /// forget to handle exceptions when getting.
    /// </summary>
    public Dictionary<string,ObservableValue<int>> ObservableInts;
    /// <summary>
    /// Dictionary of observable floats. Use ObservableFloats[name] to get a value. Don't
    /// forget to handle exceptions when getting.
    /// </summary>
    public Dictionary<string,ObservableValue<float>> ObservableFloats;
    /// <summary>
    /// Dictionary of observable bools. Use ObservableBools[name] to get a value. Don't
    /// forget to handle exceptions when getting.
    /// </summary>
    public Dictionary<string,ObservableValue<bool>> ObservableBools;
    /// <summary>
    /// Dictionary of observable Vector2s. Use ObservableVector2s[name] to get a value. Don't
    /// forget to handle exceptions when getting.
    /// </summary>
    public Dictionary<string,ObservableValue<Vector2>> ObservableVector2s;
    /// <summary>
    /// Since Awake() is called before Start(), all event handlers should be set up in respective
    /// Start() methods. If an event handler is instantiated within an Awake() method, there's
    /// risk of null exceptions for uninitialized.
    /// 
    /// Unity calls Awake on scripts derived from MonoBehaviour in the following scenarios:
    ///     * The parent GameObject is active and initializes on Scene load
    ///     * The parent GameObject goes from inactive to active
    ///     * After initialization of a parent GameObject created with Object.Instantiate

    /// </summary>
    void Awake()
    {
        
        foreach(string s in _intNames) 
        {
            ObservableInts.Add(s,new ObservableValue<int>(s));
        }
        foreach(string s in _floatNames) 
        {
            ObservableFloats.Add(s,new ObservableValue<float>(s));
        }
        foreach(string s in _boolNames)
        {
            ObservableBools.Add(s,new ObservableValue<bool>(s));
        }
        foreach(string s in _boolNames)
        {
            ObservableVector2s.Add(s,new ObservableValue<Vector2>(s));
        }
    }
    /// <summary>
    /// Instantiates empty dictionaries on class instantiation. Values from Unity inspector
    /// get added in Awake().
    /// </summary>
    public ObservableValueCollection()
    {
        ObservableInts = new Dictionary<string,ObservableValue<int>>();
        ObservableFloats = new Dictionary<string,ObservableValue<float>>();
        ObservableBools = new Dictionary<string,ObservableValue<bool>>();
        ObservableVector2s = new Dictionary<string,ObservableValue<Vector2>>();
        
    }
}
