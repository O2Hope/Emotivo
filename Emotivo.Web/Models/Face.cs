using System;
using System.Collections.ObjectModel;

namespace Emotivo.Web.Models
{
    public class Face
    {
        public int Id
        {
            get;
            set;
        }

        public int PictureID
        {
            get;
            set;
        }

        #region

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        #endregion

        public virtual Picture Picture
        {
            get;
            set;
        }

        public virtual ObservableCollection<Emotion> Emotions
        {
            get;
            set;
        }
    }
}
