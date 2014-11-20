#include "Chaine.h"
#include <iostream>
#include <cstdlib>
#include <iomanip>

int main(){

	Chaine* c1 = new Chaine();
	char input[81];
	std::cin >> input;
	Chaine ptr = Chaine(input);
	ptr.affiche();
	Chaine* c2 = new Chaine(ptr);
	Chaine::comparer(c1, c2);
	Chaine* c3 = new Chaine("Ceci est ");
	Chaine* c4 = new Chaine("un test");
	delete c2;
	Chaine* c5 = Chaine::concat(c3, c4);
	c5->affiche();
	c3->caractere(5);
	c3->sous_chaine(5, 7);
	c4->sous_chaine('n', 's');
	return 0;
}