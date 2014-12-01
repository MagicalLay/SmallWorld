#include "Algo.h"
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <time.h> 

#define SPACE_DESERT 0
#define SPACE_FIELD 1
#define SPACE_FOREST 2
#define SPACE_MOUNTAIN 3

int Algo::computeFoo() 
{ 
	return 1; 
}

/* will fill the map with the right types of spaces in a random way */
int** Algo::fillMap(int size)
{
	/* initialize random seed: */
	srand((unsigned int)time(NULL));

	/* number of spaces of each type */
	int nbSpaces = (size * size) / 4;

	/* number of spaces empty for each type */
	int spacesLeft[] = { nbSpaces, nbSpaces, nbSpaces, nbSpaces };
	int** result = (int**)malloc(size * sizeof(int *));
	int typeOfSpace;
	
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < size; j++){
			/* random number between 0 and 4 */
			typeOfSpace = rand() % 4;
			while (spacesLeft[typeOfSpace] == 0)
			{
				typeOfSpace = rand() % 4;
			}
			result[i][j] = typeOfSpace;
			spacesLeft[typeOfSpace]--;
		}
	}
	return result;
}
