class Chaine {

private:
	char* tab;
	
public:
	Chaine();
	Chaine(const char * c);
	Chaine(const Chaine & c);
	~Chaine();

	void affiche();
	static int longueur(Chaine *ch);
	static bool comparer(Chaine *ch1, Chaine *ch2);
	static Chaine* concat(Chaine *ch1, Chaine *ch2);
	bool caractere(int pos);
	bool sous_chaine(char deb, char fin);
	bool sous_chaine(int ind1, int ind2);
};