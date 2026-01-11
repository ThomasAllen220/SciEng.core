#include <gtest/gtest.h>
#include "Integration.cpp"
#include "Interpolation.cpp"
#include "MatrixOps.cpp"
#include <cmath>
#include <vector>

using namespace SciEng::Numerics;

constexpr double EPS = 1e-6;

TEST(IntegrationTests, TrapezoidalLinear)
{
	auto f = [](double x) { return 2 * x; }; //integral from 0 to 1 = 1
	double result = IntegrateTrapezoidal(f, 0.0, 1.0, 1000);
	EXPECT_NEAR(result, 1.0, EPS);
}

TEST(IntegrationTests, TrapezoidalQuadratic)
{
	auto f = [](double x) { return x * x; }; //integral from 0 to 1 = 1/3
	double result = IntegrateTrapezoidal(f, 0.0, 1.0, 1000);
	EXPECT_NEAR(result, 1.0 / 3.0, EPS);
}

TEST(InterpolationTests, LinearInterpolationMiddle)
{
	std::vector<double> x = { 0, 1, 2 };
	std::vector<double> y = { 0, 10, 20 };

	double interp = LinearInterpolate(x, y, 1.5);
	EXPECT_NEAR(interp, 15.0, EPS);
}

TEST(InterpolationTests, LinearInterpolationExtrapolateLow)
{
    std::vector<double> x = { 1, 2, 3 };
    std::vector<double> y = { 10, 20, 30 };

    double interp = LinearInterpolate(x, y, 0.0); // below x[0]
    EXPECT_DOUBLE_EQ(interp, 10.0);
}

TEST(MatrixOpsTests, Multiply2x2)
{
    Matrix a = { {1, 2}, {3, 4} };
    Matrix b = { {5, 6}, {7, 8} };

    Matrix product = Multiply(a, b);

    EXPECT_DOUBLE_EQ(product[0][0], 19);
    EXPECT_DOUBLE_EQ(product[0][1], 22);
    EXPECT_DOUBLE_EQ(product[1][0], 43);
    EXPECT_DOUBLE_EQ(product[1][1], 50);
}

TEST(MatrixOpsTests, Transpose2x3)
{
    Matrix m = { {1,2,3},{4,5,6} };
    Matrix t = Transpose(m);

    ASSERT_EQ(t.size(), 3);
    ASSERT_EQ(t[0].size(), 2);

    EXPECT_DOUBLE_EQ(t[0][0], 1);
    EXPECT_DOUBLE_EQ(t[0][1], 4);
    EXPECT_DOUBLE_EQ(t[1][0], 2);
    EXPECT_DOUBLE_EQ(t[1][1], 5);
    EXPECT_DOUBLE_EQ(t[2][0], 3);
    EXPECT_DOUBLE_EQ(t[2][1], 6);
}