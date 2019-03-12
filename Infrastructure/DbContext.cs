using ApplicationCore.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class DbContext: IdentityDbContext<User>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskDetails> TasksDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentType> CommentTypes { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TaskStatus>()
                .HasKey(k => k.Id);

            builder.Entity<TaskType>()
                .HasKey(k => k.Id);

            builder.Entity<TaskDetails>()
                .HasOne<TaskType>(td => td.Type)
                .WithMany(tt => tt.TaskDetails)
                .HasForeignKey(td => td.TypeId);

            builder.Entity<TaskDetails>()
                .HasOne<TaskStatus>(td => td.Status)
                .WithMany(ts => ts.TaskDetails)
                .HasForeignKey(td => td.StatusId);

            builder.Entity<Task>()
                .HasOne<TaskDetails>(t => t.TaskDetails)
                .WithOne(td => td.Task)
                .HasForeignKey<TaskDetails>(td => td.TaskId);

            base.OnModelCreating(builder);
        }
    }
}
