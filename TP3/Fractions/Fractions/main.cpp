#include "Fraction.h"
#include "OverflowException.h"
#include <iostream>
#include <cstdlib>
#include <iomanip>
#include <limits>

int main(){

	Fraction f1 = Fraction(6,7);
	f1.affiche();
	Fraction f2 = Fraction(4,7);
	Fraction f3 = f1 - f2;
	f3.affiche();
	try{
		f2 = f2*f3;
	}
	catch (OverflowException& e){

	}
	f2.affiche();

	std::cin.ignore();
	return 0;
}