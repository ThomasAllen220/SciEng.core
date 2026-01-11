#include <vector>
#include <stdexcept>

namespace SciEng::Numerics
{
	{
		using Matrix = std::vector<std::vector<double>>;

		//Multiply two Matrices
		Matrix Multiply(const Matrix& a, const Matrix& b)
		{
			if (a.empty() || b.empty() || a[0].size() != b.size())
				throw std::invalid_argument("Matrix dimensions incompatible for multiplication.");

			size_t rows = a.size();
			size_t cols = b[0].size();
			size_t inner = b.size();

			Matrix result(rows, std::vector<double>(cols, 0.0));

			for (size_t i = 0; i < rows; ++i)
			{
				for (size_t j = 0; j < cols; ++j)
				{
					for (size_t k = 0; k < inner; ++k)
					{
						result[i][j] += a[i][k] * b[k][j];
					}
				}
			}

			return result;
		}

		Matrix Transpose(const Matrix& m)
		{
			if (m.empty()) return Matrix{};

			size_t rows = m.size();
			size_t cols = m[0].size();
			Matrix result(cols, std::vector<double>(rows, 0.0));

			for (size_t i = 0; i < rows; ++i)
			{
				for (size_t j = 0; j < cols; ++j)
				{
					result[j][i] = m[i][j];
				}
			}

			return result;
		}
	} 
}