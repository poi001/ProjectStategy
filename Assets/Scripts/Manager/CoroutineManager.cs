using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : SingletonWithMono<CoroutineManager>, IManagerInterface
{
    private Dictionary<string, Coroutine> activeCoroutines = new Dictionary<string, Coroutine>();


    public IEnumerator Init()
    {
        yield return new WaitForSeconds(0.15f); // ← 가짜 로딩 ( 너무 로딩이 빠르면 어색하기 때문, 나중에 비동기 메서드로 교체 )
    }

    public Coroutine StartManagedCoroutine(IEnumerator routine, string key = null)
    {
        if (!string.IsNullOrEmpty(key))
        {
            if (activeCoroutines.ContainsKey(key))
            {
                StopCoroutine(activeCoroutines[key]);
                activeCoroutines.Remove(key);
            }

            Coroutine coroutine = StartCoroutine(TrackCoroutine(routine, key));
            activeCoroutines[key] = coroutine;
            return coroutine;
        }
        else
        {
            return StartCoroutine(routine);
        }
    }

    public void StopManagedCoroutine(string key)
    {
        if (activeCoroutines.TryGetValue(key, out Coroutine coroutine))
        {
            StopCoroutine(coroutine);
            activeCoroutines.Remove(key);
        }
    }

    public void StopAllManagedCoroutines()
    {
        foreach (var kvp in activeCoroutines)
        {
            StopCoroutine(kvp.Value);
        }
        activeCoroutines.Clear();
    }

    private IEnumerator TrackCoroutine(IEnumerator routine, string key)
    {
        yield return StartCoroutine(routine);
        activeCoroutines.Remove(key);
    }
}

public static class YieldCache
{
    // IEqualityComparer: 두 객체가 같은지 비교할 수 있도록 해주는 비교자,
    // 딕셔너리나 해시셋 같은 자료구조에서 키 비교 기준을 커스터마이징할 때 사용
    class FloatComparer : IEqualityComparer<float>
    {
        // IEqualityComparer<T> 인터페이스에서 Equals()와 GetHashCode()가 함께 정의된 이유는
        // Dictionary, HashSet 같은 해시 기반 컬렉션에서 키나 항목의 "같음"을 정확하게 판단하기 위해서

        // 두 float가 같은지 확인해주는 함수
        bool IEqualityComparer<float>.Equals(float x, float y)
        {
            return x == y;
        }
        // 해당 float 객체의 해시코드를 반환하는 함수
        int IEqualityComparer<float>.GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }

    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
    public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

    // 매개변수는 딕셔너리의 Key 값(float)을 어떻게 비교할지 정의해주는 도구 ( (new FloatComparer()) 이 부분 )
    // 기본 비교 대신 내가 정의한 방식으로 키를 비교
    private static readonly Dictionary<float, WaitForSeconds> _timeInterval = 
        new Dictionary<float, WaitForSeconds>(new FloatComparer());
    private static readonly Dictionary<float, WaitForSecondsRealtime> _timeIntervalReal = 
        new Dictionary<float, WaitForSecondsRealtime>(new FloatComparer());

    public static WaitForSeconds WaitForSeconds(float seconds)
    {
        WaitForSeconds wfs;
        if (!_timeInterval.TryGetValue(seconds, out wfs))
            _timeInterval.Add(seconds, wfs = new WaitForSeconds(seconds));
        return wfs;
    }

    public static WaitForSecondsRealtime WaitForSecondsRealTime(float seconds)
    {
        WaitForSecondsRealtime wfsReal;
        if (!_timeIntervalReal.TryGetValue(seconds, out wfsReal))
            _timeIntervalReal.Add(seconds, wfsReal = new WaitForSecondsRealtime(seconds));
        return wfsReal;
    }
}
