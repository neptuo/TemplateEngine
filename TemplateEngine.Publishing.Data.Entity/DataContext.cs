using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Neptuo.TemplateEngine.Publishing.Data.Entity
{
    public class DataContext : DbContext, IDbContext
    {
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<ArticleLine> ArticleLines { get; set; }
        public IDbSet<ArticleTag> ArticleTags { get; set; }

        public DataContext()
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            MapArticle(modelBuilder.Entity<Article>());
            MapArticleLine(modelBuilder.Entity<ArticleLine>());
            MapArticleTag(modelBuilder.Entity<ArticleTag>());
        }

        private void MapArticle(EntityTypeConfiguration<Article> article)
        {
            article
                .HasKey(a => a.Key)
                .Property(a => a.Version)
                .IsRowVersion();

            article
                .HasRequired(a => a.Line).WithMany();

            article
                .HasMany(a => a.Tags).WithMany();

            article
                .Property(a => a.Url)
                .IsRequired();
        }

        private void MapArticleLine(EntityTypeConfiguration<ArticleLine> articleLine)
        {
            articleLine
                .HasKey(a => a.Key)
                .Property(a => a.Version)
                .IsRowVersion();

            articleLine
                .HasMany(l => l.AvailableTags).WithMany();
        }

        private void MapArticleTag(EntityTypeConfiguration<ArticleTag> articleTag)
        {
            articleTag
                .HasKey(a => a.Key)
                .Property(a => a.Version)
                .IsRowVersion();
        }
    }
}
