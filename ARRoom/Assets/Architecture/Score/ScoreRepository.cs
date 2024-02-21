using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class ScoreRepository : Repository
    {
        private const string KEY_HITSCORE = "KEY_HITSCORE";
        private const string KEY_TOTALSCORE = "KEY_TOTALSCORE";
        public int HitScore_Record { get; set; }
        public float TotalScore_Record { get; set; }
        public override void Initialize()
        {
            TotalScore_Record = PlayerPrefs.GetFloat(KEY_TOTALSCORE, 0);
            HitScore_Record = PlayerPrefs.GetInt(KEY_HITSCORE, 0);
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(KEY_TOTALSCORE, TotalScore_Record);
            PlayerPrefs.SetInt(KEY_HITSCORE, HitScore_Record);
        }
    }
}
