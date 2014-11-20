
#pragma once
class Fraction
{

private :

	int num;
	int denom;

public:

	Fraction();
	Fraction(int a);
	Fraction(int n, int d);
	~Fraction();
	int getNum() const;
	int getDenom() const;
	double eval();
	void affiche();
	int safe_mul(int a, int b);
	Fraction operator* (const Fraction& f1);
	Fraction operator/ (const Fraction& f1);
	Fraction operator+ (const Fraction& f1);
	Fraction operator- (const Fraction& f1);
};

