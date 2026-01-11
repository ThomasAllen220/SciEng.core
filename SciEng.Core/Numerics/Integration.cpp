#include <functional>
#include <stdexcept>

namespace SciEng::Numerics
{
	// Simple numerical integration using the trapezoidal rule
	// Integrates f(x) from a to b using n steps

	double IntegrateTrapezoidal(const std::function<double(double)>& f,
								double a, double b, int n)
	{
		if (n <= 0) throw std::invalid_argument("n must be positive");
		if (b < a) throw std::invalid_argument("upper bound must be >= lower bound");

		double h = (b - a) / n;
		double sum = 0.5 * (f(a) + f(b));

		for (int i = 1; i < n; ++i)
		{
			sum += f(a + i * h);
		}

		return sum * h;
	}
}