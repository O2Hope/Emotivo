using System;
using System.Collections.ObjectModel;

namespace Emotivo.Web.Models
{
    public class Picture
    {

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
  
        public string Path
        {
            get;
            set;
        }

        public virtual ObservableCollection<Face> Faces
        {
            get;
            set;
        }
    }
}
