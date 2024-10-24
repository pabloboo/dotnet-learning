Notes on MVC official [documentation](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs)

# Testing the view returned by a Controller

We want to test if "ProductController" returns the right view.

Make sure that when the "ProductController.Details()" action is invoked, the Details view is returned.

```c#
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Controllers;

namespace StoreTests.Controllers
{
     [TestClass]
     public class ProductControllerTest
     {
          [TestMethod]
          public void TestDetailsView()
          {
               var controller = new ProductController(); // create a new instance of the ProductController class
               var result = controller.Details(2) as ViewResult; // Invoke the controller's Details() action method
               Assert.AreEqual("Details", result.ViewName); // check whether or not the view returned by the Details() action is the Details view.

          }
     }
}
```

# Testing the View Data returned by a controller

An MVC controller passes data to a view by using something called View Data.

You can write unit tests to test whether the expected data is contained in view data.

For example this test makes sure that a laptop computer is returned when you call the ProductController Details() action method.

```c#
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Controllers;

namespace StoreTests.Controllers
{
     [TestClass]
     public class ProductControllerTest
     {

          [TestMethod]
          public void TestDetailsViewData()
          {
               var controller = new ProductController();
               var result = controller.Details(2) as ViewResult; // Invoke the Details() method
               var product = (Product) result.ViewData.Model; // ViewData.Model contains the product passed to the view.
               Assert.AreEqual("Laptop", product.Name); // Verify that the product has the name "Laptop"
          }
     }
}
```

# Testing the Action Result returned by a Controller

A more complex controller action might return different types of action results depending on the values of the parameters passed to the controller action. A controller action can return a variety of types of action results including a ViewResult, RedirectToRouteResult, or JsonResult.

For example the following test verifies that you are redirected to the Index view when an Id with the value -1 is passed to the "Details()" method:

```c#
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Controllers;
namespace StoreTests.Controllers
{
     [TestClass]
     public class ProductControllerTest
     {
          [TestMethod]
          public void TestDetailsRedirect()
          {
               var controller = new ProductController();
               var result = (RedirectToRouteResult) controller.Details(-1);
               Assert.AreEqual("Index", result.Values["action"]); // check if the user is redirected to Index

          }
     }
}
```

When you call the RedirectToAction() method in a controller action, the controller action returns a RedirectToRouteResult.

# Summary

Use **ViewResult.ViewName** property to verify the name of a view.

Use **ViewData.Model** to check if the right object was returned.

Use **RedirectToRouteResult** to check if different types of action results are returned from a controller action.