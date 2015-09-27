using NUnit.Framework;

namespace Readings.Domain.Tests {
    [TestFixture]
    public class ArticleSectionTests {

        [Test]
        public void Ctor_ArticleSection_Created() {
            // Arrange
            const string title = "ArticleSectionTitle";
            const string content = "ArticleSectionContent";

            // Act
            var article = new ArticleSection(title) {Content = content};

            // Assert
            Assert.IsNotNull(article);
            Assert.AreEqual(title, article.Title);
            Assert.AreEqual(content, article.Content);
            Assert.AreEqual(0, article.Level);
            Assert.AreEqual(0, article.Order);
        }

        [Test]
        public void AddSection_OneSectionToArticleSection_CreatedSectionOfArticleSection() {
            // Arrange
            var rootArticleSection = new ArticleSection("ArticleSectionRootTitle") { Content = "ArticleSectionRootContent" };

            // Act
            var articleSection1 = rootArticleSection.AddSection("Section1Lvl1Title", "Section1Lv1Content");

            // Assert
            Assert.IsNotNull(articleSection1);
            Assert.AreEqual(1, articleSection1.Level);
            Assert.AreEqual(1, articleSection1.Order);
            Assert.AreEqual(rootArticleSection, articleSection1.Parent);
            Assert.AreEqual("Section1Lvl1Title", articleSection1.Title);
            Assert.AreEqual("Section1Lv1Content", articleSection1.Content);

            Assert.IsNotEmpty(rootArticleSection.ChildSections);
            CollectionAssert.Contains(rootArticleSection.ChildSections, articleSection1);

        }

        [Test]
        public void AddSection_MultipleSectionsToArticleSection_CreatedSectionsOfArticleSection() {
            // Arrange
            var rootArticleSection = new ArticleSection("ArticleSectionRootTitle") { Content = "ArticleSecionRootContent" };

            // Act
            var articleSection1 = rootArticleSection.AddSection("Section1Lvl1Title", "Section1Lv1Content");
            var articleSection2 = rootArticleSection.AddSection("Section2Lvl1Title", "Section2Lv1Content");
            var articleSection3 = rootArticleSection.AddSection("Section3Lvl1Title", "Section3Lv1Content");

            // Assert
            Assert.IsNotNull(articleSection1);
            Assert.AreEqual(1, articleSection1.Level);
            Assert.AreEqual(1, articleSection1.Order);
            Assert.AreEqual(rootArticleSection, articleSection1.Parent);
            Assert.AreEqual("Section1Lvl1Title", articleSection1.Title);
            Assert.AreEqual("Section1Lv1Content", articleSection1.Content);

            Assert.IsNotNull(articleSection2);
            Assert.AreEqual(1, articleSection2.Level);
            Assert.AreEqual(2, articleSection2.Order);
            Assert.AreEqual(rootArticleSection, articleSection2.Parent);
            Assert.AreEqual("Section2Lvl1Title", articleSection2.Title);
            Assert.AreEqual("Section2Lv1Content", articleSection2.Content);

            Assert.IsNotNull(articleSection3);
            Assert.AreEqual(1, articleSection3.Level);
            Assert.AreEqual(3, articleSection3.Order);
            Assert.AreEqual(rootArticleSection, articleSection3.Parent);
            Assert.AreEqual("Section3Lvl1Title", articleSection3.Title);
            Assert.AreEqual("Section3Lv1Content", articleSection3.Content);

            Assert.IsNotEmpty(rootArticleSection.ChildSections);
            Assert.AreEqual(3, rootArticleSection.ChildSections.Count);
            CollectionAssert.Contains(rootArticleSection.ChildSections, articleSection1);
            CollectionAssert.Contains(rootArticleSection.ChildSections, articleSection2);
            CollectionAssert.Contains(rootArticleSection.ChildSections, articleSection3);

        }


        [Test]
        public void AddSection_MultipleSectionsToSection_CreatedSectionsOfArticleSection() {
            // Arrange
            var rootArticleSection = new ArticleSection("ArticleSectionRootTitle") { Content = "ArticleSectionRootContent" };

            // Act
            var articleSection1 = rootArticleSection.AddSection("Section1Lvl1Title", "Section1Lv1Content");
            var articleSection2 = rootArticleSection.AddSection("Section2Lvl1Title", "Section2Lv1Content");
            var articleSection3 = rootArticleSection.AddSection("Section3Lvl1Title", "Section3Lv1Content");

            var articleSection21 = articleSection2.AddSection("Section1Lvl2Title", "Section1Lv2Content");
            var articleSection22 = articleSection2.AddSection("Section2Lvl2Title", "Section2Lv2Content");

            // Assert
            Assert.IsNotNull(articleSection2);
            Assert.AreEqual(1, articleSection2.Level);
            Assert.AreEqual(2, articleSection2.Order);
            Assert.AreEqual(rootArticleSection, articleSection2.Parent);
            Assert.AreEqual("Section2Lvl1Title", articleSection2.Title);
            Assert.AreEqual("Section2Lv1Content", articleSection2.Content);

            Assert.IsNotNull(articleSection21);
            Assert.AreEqual(2, articleSection21.Level);
            Assert.AreEqual(1, articleSection21.Order);
            Assert.AreEqual(articleSection2, articleSection21.Parent);
            Assert.AreEqual("Section1Lvl2Title", articleSection21.Title);
            Assert.AreEqual("Section1Lv2Content", articleSection21.Content);

            Assert.IsNotNull(articleSection22);
            Assert.AreEqual(2, articleSection22.Level);
            Assert.AreEqual(2, articleSection22.Order);
            Assert.AreEqual(articleSection2, articleSection22.Parent);
            Assert.AreEqual("Section2Lvl2Title", articleSection22.Title);
            Assert.AreEqual("Section2Lv2Content", articleSection22.Content);

            Assert.IsNotEmpty(rootArticleSection.ChildSections);
            Assert.AreEqual(3, rootArticleSection.ChildSections.Count);
            CollectionAssert.Contains(rootArticleSection.ChildSections, articleSection2);

            Assert.IsNotEmpty(articleSection2.ChildSections);
            Assert.AreEqual(2, articleSection2.ChildSections.Count);
            CollectionAssert.Contains(articleSection2.ChildSections, articleSection21);
            CollectionAssert.Contains(articleSection2.ChildSections, articleSection22);

        }

        [Test]
        public void Remove_ArticleSectionFromItsParent_RemovedArticleSection() {
            // Arrange
            var rootArticleSection = new ArticleSection("ArticleSectionRootTitle") { Content = "ArticleSectionRootContent" };
            var articleSection1 = rootArticleSection.AddSection("Section1Lvl1Title", "Section1Lv1Content");
            var articleSection2 = rootArticleSection.AddSection("Section2Lvl1Title", "Section2Lv1Content");
            var articleSection3 = rootArticleSection.AddSection("Section3Lvl1Title", "Section3Lv1Content");

            var articleSection21 = articleSection2.AddSection("Section1Lvl2Title", "Section1Lv2Content");
            var articleSection22 = articleSection2.AddSection("Section2Lvl2Title", "Section2Lv2Content");
            var articleSection23 = articleSection2.AddSection("Section3Lvl2Title", "Section3Lv2Content");

            // Act
            articleSection21.Remove();

            // Assert
            CollectionAssert.DoesNotContain(articleSection2.ChildSections, articleSection21);
            Assert.AreEqual(1, articleSection22.Order);
            Assert.AreEqual(2, articleSection23.Order);

        }

        [Test]
        public void ChangeOrder_ThisArticleSection_ChangedOrder() {
            // Arrange
            var rootArticleSection = new ArticleSection("ArticleSectionRootTitle") { Content = "ArticleSectionRootContent" };
            var articleSection1 = rootArticleSection.AddSection("Section1Lvl1Title", "Section1Lv1Content");
            var articleSection2 = rootArticleSection.AddSection("Section2Lvl1Title", "Section2Lv1Content");
            var articleSection3 = rootArticleSection.AddSection("Section3Lvl1Title", "Section3Lv1Content");

            var articleSection21 = articleSection2.AddSection("Section1Lvl2Title", "Section1Lv2Content");
            var articleSection22 = articleSection2.AddSection("Section2Lvl2Title", "Section2Lv2Content");
            var articleSection23 = articleSection2.AddSection("Section3Lvl2Title", "Section3Lv2Content");
            var articleSection24 = articleSection2.AddSection("Section4Lvl2Title", "Section4Lv2Content");
            var articleSection25 = articleSection2.AddSection("Section5Lvl2Title", "Section5Lv2Content");

            // Act
            articleSection22.ChangeOrder(4);

            // Assert
            Assert.AreEqual(1, articleSection21.Order);
            Assert.AreEqual(4, articleSection22.Order);
            Assert.AreEqual(2, articleSection23.Order);
            Assert.AreEqual(3, articleSection24.Order);
            Assert.AreEqual(5, articleSection25.Order);

        }

        [Test]
        public void MoveToParent_ArticleSection_MovedToParent() {
            // Arrange
            var rootArticle = new ArticleSection("ArticleSectionRootTitle") { Content = "ArticleSectionRootContent" };
            var articleSection1 = rootArticle.AddSection("Section1Lvl1Title", "Section1Lv1Content");
            var articleSection2 = rootArticle.AddSection("Section2Lvl1Title", "Section2Lv1Content");
            var articleSection3 = rootArticle.AddSection("Section3Lvl1Title", "Section3Lv1Content");

            var articleSection21 = articleSection2.AddSection("Section1Lvl2Title", "Section1Lv2Content");
            var articleSection22 = articleSection2.AddSection("Section2Lvl2Title", "Section2Lv2Content");
            var articleSection23 = articleSection2.AddSection("Section3Lvl2Title", "Section3Lv2Content");
            var articleSection24 = articleSection2.AddSection("Section4Lvl2Title", "Section4Lv2Content");
            var articleSection25 = articleSection2.AddSection("Section5Lvl2Title", "Section5Lv2Content");

            // Act
            articleSection22.MoveToParent(articleSection3);

            // Assert
            CollectionAssert.Contains(articleSection3.ChildSections, articleSection22);
            Assert.AreEqual(articleSection3, articleSection22.Parent);
            
        }



    }
}
