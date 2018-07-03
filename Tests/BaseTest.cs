using El.Test.UiTests.Helpers;
using NUnit.Framework;
//using OnlineStore.WrapperFactory;


namespace El.Test.UiTests.Tests
{
   public class BaseTest
   {
       public Application app;
      [SetUp]
       public void Start()
       {
           app = new Application();
           //Console.WriteLine(TestContext.CurrentContext.TestDirectory);
        }
        [TearDown]
        public void Quit()
        {
            app.Quit();
            app = null;
        }
      }
}
