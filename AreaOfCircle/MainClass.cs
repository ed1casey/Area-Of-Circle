namespace AreaOfCircle
{
    // Интерфейс для фигуры
    public interface IFigure
    {
        double CalculateArea(); // Метод для вычисления площади
    }

    // Класс для круга
    public class Circle : IFigure
    {
        public double Radius { get; } // Радиус круга

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Радиус должен быть положительным.", nameof(radius));
            }

            Radius = radius;
        }

        public double CalculateArea() => Math.PI * Radius * Radius; // Вычисление площади круга
    }

    // Класс для треугольника
    public class Triangle : IFigure
    {
        public double SideA { get; } // Сторона A треугольника
        public double SideB { get; } // Сторона B треугольника
        public double SideC { get; } // Сторона C треугольника

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Стороны должны быть положительными.");
            }

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("Сумма любых двух сторон должна быть больше третьей стороны.");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            // Вычисление площади треугольника по формуле Герона
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public bool IsRightAngled()
        {
            // Проверка, является ли треугольник прямоугольным
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides); // Сортируем стороны по возрастанию
            // Проверяем равенство квадрата наибольшей стороны сумме квадратов двух других
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1E-10;
        }
    }
}
