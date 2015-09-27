using System;
using System.Collections.Generic;
using Zed.Domain;

namespace Readings.Domain {
    /// <summary>
    /// Article entity
    /// </summary>
    public class ArticleSection : Entity {

        #region Fields and Properties

        /// <summary>
        /// Gets article section title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets or Sets article section content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets article section parent
        /// </summary>
        public int? ParentId { get; private set; }

        /// <summary>
        /// Article section parent
        /// </summary>
        private ArticleSection parent;

        /// <summary>
        /// Gets article section parent
        /// </summary>
        public ArticleSection Parent {
            get { return parent; }
            private set {
                parent = value;
                if (parent != null) {
                    ParentId = parent.Id;
                } else {
                    ParentId = null;
                }
            }
        }
        

        /// <summary>
        /// Gets child article sections
        /// </summary>
        public IList<ArticleSection> ChildSections { get; private set; }

        /// <summary>
        /// Gets article section level
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Gets article section order
        /// </summary>
        public int Order { get; private set; }

        #endregion

        #region Constructors and Init

        /// <summary>
        /// Default constructor that creates a new instance of ArticleSection class.
        /// </summary>
        private ArticleSection() {
            ChildSections = new List<ArticleSection>();
        }

        /// <summary>
        /// Creates an article section instance
        /// </summary>
        /// <param name="title">Article section title</param>
        public ArticleSection(string title) : this() {
            if(string.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            this.Title = title;
            Level = 0;
            Order = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds article section to article section
        /// </summary>
        /// <param name="sectionTitle">Section title</param>
        /// <param name="sectionContent">Section content</param>
        /// <returns>Article section added to this article section</returns>
        public ArticleSection AddSection(string sectionTitle, string sectionContent) {
            if (string.IsNullOrEmpty(sectionTitle)) throw new ArgumentNullException("sectionTitle");
            if (string.IsNullOrEmpty(sectionContent)) throw new ArgumentNullException("sectionContent");

            var articleSection = new ArticleSection(sectionTitle) {
                Content = sectionContent,
                Level = Level + 1,
                Order = ChildSections.Count + 1,
                Parent = this
            };

            AddSection(articleSection);

            return articleSection;

        }

        /// <summary>
        /// Adds article section to article section.
        /// It will try to satisfy provided order but if it is impossible
        /// to satisfy order will be added last in group.
        /// </summary>
        /// <param name="articleSectionSection">Article section to be added as child of this article section</param>
        public void AddSection(ArticleSection articleSectionSection) {
            if (articleSectionSection == null) throw new ArgumentNullException("articleSectionSection");
            if (this.Equals(articleSectionSection)) throw new InvalidOperationException("Can't add to itself.");

            var requestedOrder = articleSectionSection.Order;

            articleSectionSection.Parent = this;
            articleSectionSection.Level = this.Level + 1;


            ChildSections.Add(articleSectionSection);
            reorder(ChildSections);

            try {
                articleSectionSection.ChangeOrder(requestedOrder);
            } catch (ArgumentOutOfRangeException ex) { }

        }

        /// <summary>
        /// Removes this article section from its article section parent / tree
        /// </summary>
        public void Remove() { RemoveSection(this); }

        /// <summary>
        /// Removes article section from article section parent.
        /// </summary>
        /// <param name="articleSection">Article section to remove from its parent</param>
        public static void RemoveSection(ArticleSection articleSection) {
            if(articleSection == null) throw new ArgumentNullException("articleSection");

            if (articleSection.Parent != null && articleSection.Parent.ChildSections.Count > 0) {
                articleSection.Parent.ChildSections.Remove(articleSection); ;
                reorder(articleSection.Parent.ChildSections);
                articleSection.Parent = null;    
            }

        }

        /// <summary>
        /// Changes this article section order in its level group
        /// </summary>
        /// <param name="order">Order of this article section in its level group</param>
        public void ChangeOrder(int order) {
            if (Parent == null || Order == order) return;

            if (order < 1 || order > Parent.ChildSections.Count) throw new ArgumentOutOfRangeException();

            Parent.ChildSections.Remove(this);

            Order = order;
            Parent.ChildSections.Insert(order-1, this);
            reorder(Parent.ChildSections);
        }

        /// <summary>
        /// Moves this article section to requested parent
        /// </summary>
        /// <param name="newParent">Parent which will contain this article section</param>
        public void MoveToParent(ArticleSection newParent) {
            if(newParent == null) throw new ArgumentNullException("newParent");

            this.Remove();
            newParent.AddSection(this);

        }

        /// <summary>
        /// Reorders article section based on it's index in article sections list
        /// </summary>
        /// <param name="articleSections">Article sections list</param>
        private static void reorder(IList<ArticleSection> articleSections) {
            for (var i = 0 ; i < articleSections.Count ; i++) {
                articleSections[i].Order = i+1;
            }
        }

        public override string ToString() {
            return String.Format("Id: {0}:{1}, Title: {2}, Lvl: {3}, Order: {4}", Parent != null ? Parent.Id.ToString() : "NULL", Id, Title, Level, Order);
        }

        #endregion

    }
}
