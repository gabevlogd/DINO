using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager<TEventID> 
{
    private Dictionary<TEventID, List<Action>> m_events;

    public EventManager()
    {
        m_events = new Dictionary<TEventID, List<Action>>();
    }

    /// <summary>
    /// Registers a new obrever at the passed event
    /// </summary>
    /// /// <param name="key">Event ID</param>
    public void Register(TEventID key, Action observerToRegister)
    {
        if (m_events.ContainsKey(key))
            m_events[key].Add(observerToRegister);
        else
        {
            m_events.Add(key, new List<Action>());
            m_events[key].Add(observerToRegister);
        }
    }

    /// <summary>
    /// Unregisters an obrever from the passed event
    /// </summary>
    /// <param name="key">Event ID</param>
    public void Unregister(TEventID key, Action observerToUnregister)
    {
        if (!IsValidKey(key)) return;
        if (!m_events[key].Contains(observerToUnregister))
        {
            Debug.Log("EventManager do not contains " + observerToUnregister + " in the " + key.ToString() + " event");
            return;
        }

        m_events[key].Remove(observerToUnregister);
    }

    /// <summary>
    /// Sends a trigger notification to observers of the passed event
    /// </summary>
    /// <param name="key">ID of the event to be triggered</param>
    public void TriggerEvent(TEventID key)
    {
        if (!IsValidKey(key)) return;

        foreach (Action @event in m_events[key])
            @event.Invoke();
    }

    /// <summary>
    /// Checks if the passed key is contained in the dictionary
    /// </summary>
    public bool IsValidKey(TEventID key)
    {
        if (!m_events.ContainsKey(key))
        {
            Debug.Log("EventManager do not contains an event with the ID : " + key.ToString());
            return false;
        }
        else return true;
    }

    

}