using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageLogger : MonoBehaviour
{
    #region Singleton
    public static PassageLogger Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    private Stack<Passage> logs = new Stack<Passage>();
    public Stack<Passage> Logs { get => logs; }

    public void PushPassage(Passage passage)
    {
        Logs.Push(passage);
    }

    public Passage PopPassage()
    {
        return Logs.Pop(); 
    }
}
