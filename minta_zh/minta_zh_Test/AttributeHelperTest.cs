using NUnit.Framework;
using minta_zh;


namespace minta_zh_Test
{
    public class AttributeHelperTest
    {
        [Test]
        public void HasDisplayName()
        {
            var TestAttributeName = minta_zh.AttributeHelper.GetPropertyDisplayName<Product>(nameof(Product.Name));

            Assert.AreEqual("Termék neve", TestAttributeName);
        } 
        
        [Test]
        public void FalseHasDisplayName()
        {
            var TestAttributeName = minta_zh.AttributeHelper.GetPropertyDisplayName<Ingredient>(nameof(Ingredient.Name));

            Assert.IsNull(TestAttributeName);
        }  
        
        [Test]
        public void NullHasDisplayName()
        {
            var TestAttributeName = minta_zh.AttributeHelper.GetPropertyDisplayName<Ingredient>(null);

            Assert.AreEqual("", TestAttributeName);
        }
    }
}