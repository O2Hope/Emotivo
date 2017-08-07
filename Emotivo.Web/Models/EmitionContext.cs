using System;
using Microsoft.EntityFrameworkCore;

namespace Emotivo.Web.Models
{
    public class EmitionContext : DbContext
    {
        public EmitionContext( DbContextOptions options ) :base(options)
        {
            
        }

        public EmitionContext()
        {

        }

        public DbSet<Emotion> Emotions
        {
            get;
            set;
        }

        public DbSet<Face> Faces
        {
            get;
            set;
        }

        public DbSet<Picture> Pictures
        {
            get;
            set;
        }
    }
}
