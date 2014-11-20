#include "Fraction.h"
#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <limits>
#include "OverflowException.h"
#include "DivByZeroException.h"
#include "ZeroAsDenumException.h"

Fraction::Fraction()
{
}

Fraction::~Fraction()
{
}

Fraction::Fraction(int a){
	num = a;
	denom = 1;
}

Fraction::Fraction(int n, int d){
	num = n;
	denom = d;
}

int Fraction::getNum() const{
	return num;
}

int Fraction::getDenom() const{
	return denom;
}

double Fraction::eval(){
	return getNum()/getDenom();
}

void Fraction::affiche(){
	std::cout << "num=" << this->getNum() << " et denom ="<<this->getDenom()<<"\n";
}

int Fraction::safe_mul(int a, int b){
	if(a > std::numeric_limits<int>::max()/b) throw OverflowException();
	return a*b;
}

Fraction Fraction::operator* (const Fraction& f1){
	int n = safe_mul(this->getNum(), f1.getNum());
	int d = this->getDenom()* f1.getDenom();
	return Fraction(n, d);
}

Fraction Fraction::operator/ (const Fraction& f1){
	int n = this->getNum()* f1.getDenom();
	int d = this->getDenom()* f1.getNum();
	return Fraction(n, d);
}

Fraction Fraction::operator+ (const Fraction& f1){
	int d = this->getDenom()*f1.getDenom();
	int n = this->getNum()*f1.getDenom() + this->getDenom()*f1.getNum();
	return Fraction(n, d);
}

Fraction Fraction::operator- (const Fraction& f1){
	int d = this->getDenom()*f1.getDenom();
	int n = this->getNum()*f1.getDenom() - this->getDenom()*f1.getNum();
	return Fraction(n, d);
}