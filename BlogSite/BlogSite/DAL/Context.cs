using BlogSite.Models.EntityModels;
using System.Data.Entity;

namespace BlogSite.DAL
{
    public class Context : DbContext, IContext
    {
        public Context()
            : base("name=LocalDb")
        {
            Database.SetInitializer(new DbInitializer());
        }

        //public IDbSet<User> Users { get; set; }
        //public IDbSet<Song> Song { get; set; }
        //public IDbSet<Post> Post { get; set; }
        //public IDbSet<Message> Message { get; set; }
        //public IDbSet<Follow> Follow { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UserConfiguration());
            //modelBuilder.Configurations.Add(new SongConfiguration());
            //modelBuilder.Configurations.Add(new PostConfiguration());
            //modelBuilder.Configurations.Add(new MessageConfiguration());
            //modelBuilder.Configurations.Add(new FollowConfiguration());
        }
    }
}