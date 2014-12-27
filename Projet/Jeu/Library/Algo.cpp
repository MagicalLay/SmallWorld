#include "Algo.h"
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <time.h> 

#define SPACE_DESERT 0
#define SPACE_FIELD 1
#define SPACE_FOREST 2
#define SPACE_MOUNTAIN 3

/* fills the map with the 4 types of spaces in a random way */
int** Algo::fillMap(int size)
{
	/* initialize random seed */
	srand((unsigned int)time(NULL));

	/* number of spaces of each type */
	int nbSpaces = (size * size) / 4;

	/* number of spaces empty for each type */
	int spacesLeft[] = { nbSpaces, nbSpaces, nbSpaces, nbSpaces };
	int** result = (int**)malloc(size * sizeof(int *));
	int typeOfSpace;
	
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < size; j++){
			/* random number between 0 and 3 included */
			typeOfSpace = rand() % 4;
			while (spacesLeft[typeOfSpace] == 0)
			{
				typeOfSpace = rand() % 4;
			}
			/* fill the result tab */
			result[i][j] = typeOfSpace;
			spacesLeft[typeOfSpace]--;
		}
	}
	return result;
}

/* finds the initial coordinates for each player */
int* initialCoord(int* map, int size){

	/* initialize random seed */
	srand((unsigned int)time(NULL));

	/* initialize the result */
	int* coord = (int*)malloc(4 * sizeof(int));

	/* random number equal to 0 or 1 */
	int pos = rand() % 2;

	int i1, j1, i2, j2;
	/* the players must be very far away from each other : 2 possibilities on the map */
	if (pos == 1){
		i1 = rand() % 2;
		j1 = size - rand() % 2;
		i2 = size - rand() % 2;
		j2 = rand() % 2;
	}
	else
	{
		i1 = rand() % 2;
		j1 = rand() % 2;
		i2 = size - rand() % 2;
		j2 = size - rand() % 2;
	}
	/* coordinates for player 1 */
	coord[0] = i1;
	coord[1] = j1;
	/* coordinates for player 2 */
	coord[2] = i2;
	coord[3] = j2;

	return coord;
}
