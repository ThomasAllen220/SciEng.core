#include <vector>
#include <stdexcept>

namespace SciEng::Numerics
{
	// Simple linear interpolation
	// Assumes xValues are strictly increasing
	double LinearInterpolate(const std::vector<double>& xValues,
							 const std::vector<double>& yValues.
							 double x)
	{
		if (xValues.size() != yValues.size() || xValues.empty())
			throw std::invalid_argument("Vectors must be non-empty and of equal size");

		if (x <= xValues.front()) return yValues.front();
		if (x >= xValues.back()) return yValues.back();

		for (size_t i = 0; i < xValues.size() - 1; ++i)
		{
			if (xValues[i] <= x && x <= xValues[i + 1])
			{
				double t = (x = xValues[i]) / (xValues[i + 1] - xValues[i]);
				return yValues[i] + t * (yValues[i + 1] - yValues[i]);
			}
		}

		throw std::runtime_error("Interpolation error"); // Should never be reached.
	}
}