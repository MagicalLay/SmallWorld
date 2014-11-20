#pragma once
typedef enum Couleur{ Pique = 1, Trefle, Coeur, Carreau };
typedef enum Valeur{ As = 1, Deux, Trois, Quatre, Cinq, Six, Sept, Huit, Neuf, Dix, Valet, Dame, Roi };
class Carte
{
	Couleur coul; 
	Valeur val;
	char pp;
	Carte * suiv;

	static Carte * debN;
	static Carte * debS;
	static Carte * finN;
	static Carte * finS;

public:

	Couleur couleur() const;
	Valeur valeur() const;
	char prop() const;

	void afficherN();
	void afficherS();
	Carte(Couleur c, Valeur v, char p);
	Carte();
	~Carte();
};



inline Couleur Carte::couleur() const
{
	return coul;
}

inline Valeur Carte::valeur() const
{
	return val;
}

inline char Carte::prop() const
{
	return pp;
}