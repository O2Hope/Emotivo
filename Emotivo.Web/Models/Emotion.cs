using System;
using System.Collections.ObjectModel;

namespace Emotivo.Web.Models
{
    public class Emotion
    {
       public int Id
        {
            get;
            set;
        }

        public float Score
        {
            get;
            set;
        }

        public EmotionEnum EmotionType
        {
            get;
            set;
        }

        public virtual Face Face
        {
            get;
            set;
        }
    }
}
