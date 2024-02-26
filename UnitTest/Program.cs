using AreaOfCircle;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace GeometryLibraryTests
{
    [TestFixture]
    public class FigureTests
    {
        [Test]
        public void Circle_WithPositiveRadius_CalculatesCorrectArea()
        {
            // Тест на корректность вычисления площади круга
            var circle = new Circle(5);
            var expectedArea = Math.PI * 25;
            ClassicAssert.AreEqual(expectedArea, circle.CalculateArea(), 1E-10);
        }

        [Test]
        public void Triangle_WithSidesOfRightAngled_CalculatesCorrectAreaAndIsRightAngled()
        {
            // Тест на корректность вычисления площади треугольника и проверку на прямоугольность
            var triangle = new Triangle(3, 4, 5);
            var expectedArea = 6;
            ClassicAssert.AreEqual(expectedArea, triangle.CalculateArea(), 1E-10);
            ClassicAssert.IsTrue(triangle.IsRightAngled());       
        }
    }
}
