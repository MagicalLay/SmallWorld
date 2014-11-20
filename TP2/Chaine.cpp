#include "Chaine.h"
#include <iostream>
#include <cstdlib>
#include <iomanip>
#include "OverflowException.h"
#include "DivByZeroException.h"
#include "ZeroAsDenumException.h"

Chaine::Chaine(){
	char* str = new char[1];
	str[0] = '\0';
	this->tab = str;
	std::cout << "Creation d'une chaine vide \n";
}

Chaine::Chaine(const char * c){
	int i = 0;
	int j = 0;
	while (c[j] != '\0') {
		j++;
	}
	char* res = new char[j+1];
	while (c[i] != '\0') {
		res[i] = c[i];
		i++;
	};
	res[j] = '\0';
	this->tab = res;
	std::cout << "Creation (par pointeur) d'une chaine de longueur " << j << "\n";
}

Chaine::Chaine(const Chaine & c){
int i = 0;
int j = 0;
while (c.tab[j] != '\0') {
	j++;
}
char* res = new char[j + 1];
while (c.tab[i] != '\0') {
	res[i] = c.tab[i];
	i++;
};
res[j] = '\0';
this->tab = res;
std::cout << "Creation (par reference) d'une chaine de longueur " << j << "\n";
}

Chaine::~Chaine() {
	delete [] this->tab;
	std::cout << "Suppression d'une chaine \n";
}

void Chaine::affiche(){

	if (this->tab[0] == '\0') { std::cout << "Chaine vide\n"; }
	else {
		std::cout << this->tab;
		std::cout << "\n";
	}
}

int Chaine::longueur(Chaine *ch){
	
	int i = 0;
	while (ch->tab[i] != '\0') {
		i++;
	}
	return i;
}

bool Chaine::comparer(Chaine* ch1, Chaine* ch2){
	
	int l1 = longueur(ch1);
	int l2 = longueur(ch2);

	if (l1 != l2) { std::cout << "Les deux chaines ne sont pas egales\n"; return false; }
	else {
		int i;
		for (i = 0; i < l1 + 1; i++){
			if (ch1->tab[i] != ch2->tab[i]) {
				std::cout << "Les deux chaines ne sont pas egales\n";
				return false;
			}
		}
		std::cout << "Les deux chaines sont egales\n";
		return true;
	}
}

Chaine *Chaine::concat(Chaine *ch1, Chaine *ch2) {

	int l1 = longueur(ch1);
	int l2 = longueur(ch2);

	int l = l1 + l2;
	char * res = new char[l];

	int i, j;
	for (i = 0; i < l1; i++){
		res[i] = ch1->tab[i];
	}
	for (j = 0; j < l2; j++){
		res[i+j] = ch2->tab[j];
	}
	res[l] = '\0';
	Chaine* r = new Chaine(res);
	std::cout << "Concatenation reussie\n";
	return r;
	}

bool Chaine::caractere(int pos){
	if (pos > longueur(this) - 1 || pos < 0) {
		std::cout << "La position demandee n'existe pas\n";
		return false;
	} else {
		std::cout << "Le caractere demande est : " << this->tab[pos] << "\n";
		return true;
	}
}

bool Chaine::sous_chaine(char deb, char fin){

	int i, j;
	int ind1 = -1;
	int ind2 = -1;

	for (i = 0; i < longueur(this); i++) {
		if (this->tab[i] == deb) {
			ind1 = i;
		}
	}
	if (ind1 == -1) {
		std::cout << "Premier caractere introuvable\n";
		return false;
	}
	else {
		for (j = ind1+1; j < longueur(this); j++) {
			if (this->tab[j] == fin) {
				ind2 = j;
			}
		}
		if (ind2 == -1) {
			std::cout << "Dernier caractere introuvable\n";
			return false;
		}
	}
	this->sous_chaine(ind1, ind2);
}
bool Chaine::sous_chaine(int ind1, int ind2) {

	int i;
	char* res = new char[ind2 - ind1 + 1];

	if (ind1 > longueur(this) - 1 || ind1 < 0 || ind2 > longueur(this) || ind2 < 0) {
		std::cout << "La position demandee n'existe pas\n";
		return false;
	}
	else {
		for (i = ind1; i < ind2 + 1; i++) {
			res[i - ind1] = this->tab[i];
		}
		res[i - ind1] = '\0';
	}
	std::cout << "La sous-chaine demandee est : " << res << "\n";
	return true;
}
