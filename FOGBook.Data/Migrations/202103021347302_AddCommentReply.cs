namespace FOGBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentReply : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ReplyId = c.Int(),
                        Text = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        CommentAuthor = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Replies", t => t.ReplyId)
                .Index(t => t.ReplyId);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        ReplyAuthor = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReplyId);
            
            AddColumn("dbo.Posts", "CommentId", c => c.Int());
            AddColumn("dbo.Posts", "ReplyId", c => c.Int());
            AddColumn("dbo.Posts", "PostAuthor", c => c.Guid(nullable: false));
            CreateIndex("dbo.Posts", "CommentId");
            CreateIndex("dbo.Posts", "ReplyId");
            AddForeignKey("dbo.Posts", "CommentId", "dbo.Comments", "CommentId");
            AddForeignKey("dbo.Posts", "ReplyId", "dbo.Replies", "ReplyId");
            DropColumn("dbo.Posts", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Author", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Posts", "ReplyId", "dbo.Replies");
            DropForeignKey("dbo.Posts", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ReplyId", "dbo.Replies");
            DropIndex("dbo.Posts", new[] { "ReplyId" });
            DropIndex("dbo.Posts", new[] { "CommentId" });
            DropIndex("dbo.Comments", new[] { "ReplyId" });
            DropColumn("dbo.Posts", "PostAuthor");
            DropColumn("dbo.Posts", "ReplyId");
            DropColumn("dbo.Posts", "CommentId");
            DropTable("dbo.Replies");
            DropTable("dbo.Comments");
        }
    }
}
