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

            builder.Entity<Comment>()
                .Property(c => c.CommentText)
                .IsRequired();

            builder.Entity<CommentType>()
                .Property(ct => ct.Type)
                .IsRequired();

            builder.Entity<TaskDetails>()
                .Property(td => td.Description)
                .IsRequired();

            builder.Entity<TaskStatus>()
                .Property(ts => ts.Name)
                .IsRequired();

            builder.Entity<TaskType>()
                .Property(tt => tt.Name)
                .IsRequired();

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

            builder.Entity<UserTask>()
                .HasKey(ut => new { ut.UserId, ut.TaskId });

            builder.Entity<UserTask>()
                .HasOne<User>(ut => ut.User)
                .WithMany(u => u.UserTasks)
                .HasForeignKey(ut => ut.UserId);

            builder.Entity<UserTask>()
                .HasOne<Task>(ut => ut.Task)
                .WithMany(t => t.UserTasks)
                .HasForeignKey(ut => ut.TaskId);

            builder.Entity<CommentType>()
                .HasKey(ct => ct.Id);

            builder.Entity<Comment>()
                .HasOne<CommentType>(c => c.CommentType)
                .WithMany(ct => ct.Comments)
                .HasForeignKey(c => c.CommentTypeId);

            builder.Entity<Comment>()
                .HasOne<Task>(c => c.Task)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskId);

            base.OnModelCreating(builder);
        }
    }
}
