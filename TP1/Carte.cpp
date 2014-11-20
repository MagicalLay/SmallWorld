#include "Carte.h"


Carte::Carte()
{
}


Carte::~Carte()
{
}

Carte::Carte(Couleur c, Valeur v, char p)
{
	coul = c;
	val = v;
	pp = p;

	if (pp == 'N'){
		if (debN == nullptr){
			suiv = nullptr;
			debN = this;
			finN = this;
		}
		else {
			finN->suiv = this;
			suiv = nullptr;
			finN = this;
		}
	}
}

void Carte::afficherN(){
}
