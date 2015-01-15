#include "Algo.h"
#include <stdlib.h>
#include <stdio.h>
#include <algorithm>
#include <time.h> 

#define DESERT_SPACE 0
#define FIELD_SPACE 1
#define FOREST_SPACE 2
#define MOUNTAIN_SPACE 3

#define INIT_SPACE 0
#define POSSIBLE_SPACE 1
#define IMPOSSIBLE_SPACE 2
#define BEST_SPACE 3

/* Fills the map with the 4 types of spaces in a random way */

int* Algo::fillMap(int size)
{
	srand((unsigned int)time(NULL));

	int nbSpaces = (size * size) / 4;

	int spacesLeft[] = { nbSpaces, nbSpaces, nbSpaces, nbSpaces };
	int* result = ((int*)malloc((size*size) * sizeof(int*)));
	int typeOfSpace;
	
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < size; j++){

			typeOfSpace = rand() % 4;
			while (spacesLeft[typeOfSpace] == 0)
			{
				typeOfSpace = rand() % 4;
			}

			result[i*size+j] = typeOfSpace;
			spacesLeft[typeOfSpace]--;
		}
	}
	return result;
}

/* Initial coordinates for each player */

int* Algo::initialCoord(int* map, int size)
{
	srand((unsigned int)time(NULL));

	int* coord = (int*)malloc(4 * sizeof(int));
	int pos = rand() % 2;

	int i1, j1, i2, j2;

	if (pos == 1){
		i1 = rand() % 2;
		j1 = size - 1 - rand() % 2;
		i2 = size - 1 - rand() % 2;
		j2 = rand() % 2;
	}
	else
	{
		i1 = rand() % 2;
		j1 = rand() % 2;
		i2 = size - 1 - rand() % 2;
		j2 = size - 1 - rand() % 2;
	}

	// Coordinates for player 1
	coord[0] = i1;
	coord[1] = j1;
	// Coordinates for player 2
	coord[2] = i2;
	coord[3] = j2;

	return coord;
}