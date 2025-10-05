using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
    [NonSerialized]
    public Dictionary<TKey, TValue> Dict = new Dictionary<TKey, TValue>();

    [SerializeField]
    private List<TKey> keys= new List<TKey>();
    [SerializeField]
    private List<TValue> values = new List<TValue>();


    // 직렬화된 데이터를 다시 객체로 변환(Deserialize)할 때
    public void OnAfterDeserialize()
    {
        Dict = new Dictionary<TKey, TValue>();

        for (int i = 0; i < Math.Min(keys.Count, values.Count); i++)
        {
            Dict[keys[i]] = values[i];
        }
    }

    // 직렬화 할 때
    public void OnBeforeSerialize()
    {
        if (Dict == null) return;

        keys.Clear();
        values.Clear();

        var copy = new Dictionary<TKey, TValue>(Dict);

        foreach (var kvp in copy)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }
}
