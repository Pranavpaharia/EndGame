using System;

namespace Models
{
    [Serializable]
    public class Score
    { 
        public string score_id;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}

