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

int** Algo::fillMap(int size)
{
	// Initialize random seed 
	srand((unsigned int)time(NULL));

	// Number of spaces of each type
	int nbSpaces = (size * size) / 4;

	// Number of spaces empty for each type
	int spacesLeft[] = { nbSpaces, nbSpaces, nbSpaces, nbSpaces };
	int** result = (int**)malloc(size * sizeof(int *));
	int typeOfSpace;
	
	for (int i = 0; i < size; i++) {
		for (int j = 0; j < size; j++){
			// Random number between 0 and 3 included
			typeOfSpace = rand() % 4;
			while (spacesLeft[typeOfSpace] == 0)
			{
				typeOfSpace = rand() % 4;
			}
			// Fills the result tab
			result[i][j] = typeOfSpace;
			spacesLeft[typeOfSpace]--;
		}
	}
	return result;
}

/* Initial coordinates for each player */

int* Algo::initialCoord(int* map, int size)
{
	// Initialize random seed
	srand((unsigned int)time(NULL));

	int* coord = (int*)malloc(4 * sizeof(int));

	// Random number equal to 0 or 1
	int pos = rand() % 2;

	int i1, j1, i2, j2;
	// Players must be far away from each other : 2 possibilities on the map
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
	// Coordinates for player 1
	coord[0] = i1;
	coord[1] = j1;
	// Coordinates for player 2
	coord[2] = i2;
	coord[3] = j2;

	return coord;
}

/* Moves for the Orcs */

void Algo::initializeOrcMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints)
{
	// By default every space is initialized
	int i, j;
	for (i = 0; i < size; i++)
	{
		for (j = 0; j < size; j++)
		{
			moves[i*size + j] = INIT_SPACE;
		}
	}
	// movePoints are set to zero
	for (i = 0; i < size; i++)
	{
		for (j = 0; j < size; j++)
		{
			moves[i*size + j] = 0;
		}
	}
	// Initial space is authorized
	moves[x*size + y] = INIT_SPACE;
	costs[x*size + y] = movePoints;
	orcPossibleMovement(map, size, x, y, moves, costs);
}

void Algo::orcPossibleMovement(int* map, int size, int x, int y, int* moves, double* costs)
{
	// Spaces above
	if (x != 0)
	{
		// Above left
		if (moves[(x - 1)*size + y] == INIT_SPACE){
			orcMovement(map, costs, size, (x - 1), y, costs[(x - 1)*size + y], moves);
			orcPossibleMovement2(map, size, (x - 1), y, moves, costs);
		}
		// Above right
		if (y != size - 1)
		{
			if (moves[(x - 1)*size + (y + 1)] == INIT_SPACE)
			{
				orcMovement(map, costs, size, (x - 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
				orcPossibleMovement2(map, size, (x - 1), y, moves, costs);
			}
		}
	}
	if (y != 0)
	{
		// Space on the left
		if (moves[x*size + (y - 1)] == INIT_SPACE){
			orcMovement(map, costs, size, x, (y - 1), costs[x*size + (y - 1)], moves);
			orcPossibleMovement2(map, size, x, (y - 1), moves, costs);
		}
	}
	if (y != size - 1)
	{
		// Space on the right
		if (moves[x*size + (y + 1)] == INIT_SPACE){
			orcMovement(map, costs, size, x, (y + 1), costs[x*size + (y + 1)], moves);
			orcPossibleMovement2(map, size, x, (y + 1), moves, costs);
		}
	}
	// Spaces below
	if (x = !size - 1)
	{
		// Below left
		if (moves[(x + 1)*size + y - 1] == INIT_SPACE)
		{
			orcMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			orcPossibleMovement2(map, size, (x + 1), (y - 1), moves, costs);
		}
		// Below right
		if (moves[(x + 1)*size + (y - 1)] == INIT_SPACE)
		{
			orcMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			orcPossibleMovement2(map, size, (x + 1), (y - 1), moves, costs);
		}
	}
}
void Algo::orcPossibleMovement2(int* map, int size, int x, int y, int* moves, double* costs)
{
	// Spaces above
	if (x != 0)
	{
		// Above left
		if (moves[(x - 1)*size + y] == INIT_SPACE){
			orcMovement(map, costs, size, (x - 1), y, costs[(x - 1)*size + y], moves);
		}
		// Above right
		if (y != size - 1)
		{
			if (moves[(x - 1)*size + (y + 1)] == INIT_SPACE)
			{
				orcMovement(map, costs, size, (x - 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			}
		}
	}
	if (y != 0)
	{
		// Space on the left
		if (moves[x*size + (y - 1)] == INIT_SPACE){
			orcMovement(map, costs, size, x, (y - 1), costs[x*size + (y - 1)], moves);
		}
	}
	if (y != size - 1)
	{
		// Space on the right
		if (moves[x*size + (y + 1)] == INIT_SPACE){
			orcMovement(map, costs, size, x, (y + 1), costs[x*size + (y + 1)], moves);
		}
	}
	// Spaces below
	if (x = !size - 1)
	{
		// Below on the left
		if (moves[(x + 1)*size + y - 1] == INIT_SPACE)
		{
			orcMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
		}
		// Below on the right
		if (moves[(x + 1)*size + (y - 1)] == INIT_SPACE)
		{
			orcMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
		}
	}
}

void Algo::orcMovement(int* map, double* costs, int size, int x, int y, double movePoints, int* moves)
{
	double mvt = movePoints;
	switch (map[size*x + y])
	{
	case FIELD_SPACE:
		if (mvt >= 0.5){
			mvt = mvt - 0.5;
			moves[x*size + y] = BEST_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case MOUNTAIN_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case FOREST_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case DESERT_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	default:
		break;
	}
}

/* Moves for the Elves */

void Algo::initializeElfMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints)
{
	// By default each space is initialized
	int i, j;
	for (i = 0; i < size; i++)
	{
		for (j = 0; j < size; j++)
		{
			moves[i*size + j] = INIT_SPACE;
		}
	}
	// movePoints are set to zero
	for (i = 0; i < size; i++)
	{
		for (j = 0; j < size; j++)
		{
			moves[i*size + j] = 0;
		}
	}
	// Initial space is authorized
	moves[x*size + y] = INIT_SPACE;
	costs[x*size + y] = movePoints;
	elfPossibleMovement(map, size, x, y, moves, costs);
}
void Algo::elfPossibleMovement(int* map, int size, int x, int y, int* moves, double* costs)
{
	// Spaces above
	if (x != 0)
	{
		// Above left
		if (moves[(x - 1)*size + y] == INIT_SPACE){
			elfMovement(map, costs, size, (x - 1), y, costs[(x - 1)*size + y], moves);
			elfPossibleMovement2(map, size, (x - 1), y, moves, costs);
		}
		// Above right
		if (y != size - 1)
		{
			if (moves[(x - 1)*size + (y + 1)] == INIT_SPACE)
			{
				elfMovement(map, costs, size, (x - 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
				elfPossibleMovement2(map, size, (x - 1), y, moves, costs);
			}
		}
	}
	if (y != 0)
	{
		// Space on the left
		if (moves[x*size + (y - 1)] == INIT_SPACE){
			elfMovement(map, costs, size, x, (y - 1), costs[x*size + (y - 1)], moves);
			elfPossibleMovement2(map, size, x, (y - 1), moves, costs);
		}
	}
	if (y != size - 1)
	{
		// Space on the right
		if (moves[x*size + (y + 1)] == INIT_SPACE){
			elfMovement(map, costs, size, x, (y + 1), costs[x*size + (y + 1)], moves);
			elfPossibleMovement2(map, size, x, (y + 1), moves, costs);
		}
	}
	// Spaces below
	if (x = !size - 1)
	{
		// Below left
		if (moves[(x + 1)*size + y - 1] == INIT_SPACE)
		{
			elfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			elfPossibleMovement2(map, size, (x + 1), (y - 1), moves, costs);
		}
		// Below right
		if (moves[(x + 1)*size + (y - 1)] == INIT_SPACE)
		{
			elfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			elfPossibleMovement2(map, size, (x + 1), (y - 1), moves, costs);
		}
	}
}
void Algo::elfPossibleMovement2(int* map, int size, int x, int y, int* moves, double* costs)
{
	// Spaces above
	if (x != 0)
	{
		// Above left
		if (moves[(x - 1)*size + y] == INIT_SPACE){
			elfMovement(map, costs, size, (x - 1), y, costs[(x - 1)*size + y], moves);
		}
		// Above right
		if (y != size - 1)
		{
			if (moves[(x - 1)*size + (y + 1)] == INIT_SPACE)
			{
				elfMovement(map, costs, size, (x - 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			}
		}
	}
	if (y != 0)
	{
		// Space on the left
		if (moves[x*size + (y - 1)] == INIT_SPACE){
			elfMovement(map, costs, size, x, (y - 1), costs[x*size + (y - 1)], moves);
		}
	}
	if (y != size - 1)
	{
		// Space on the right
		if (moves[x*size + (y + 1)] == INIT_SPACE){
			elfMovement(map, costs, size, x, (y + 1), costs[x*size + (y + 1)], moves);
		}
	}
	// Spaces below
	if (x = !size - 1)
	{
		// Below left
		if (moves[(x + 1)*size + y - 1] == INIT_SPACE)
		{
			elfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
		}
		// Below right
		if (moves[(x + 1)*size + (y - 1)] == INIT_SPACE)
		{
			elfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
		}
	}
}
void Algo::elfMovement(int* map, double* costs, int size, int x, int y, double movePoints, int* moves)
{
	double mvt = movePoints;
	switch (map[size*x + y])
	{
	case FOREST_SPACE:
		if (mvt >= 0.5){
			mvt = mvt - 0.5;
			moves[x*size + y] = BEST_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case MOUNTAIN_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case FIELD_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else
		{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case DESERT_SPACE:
		// I think it is impossible that mvt >= 2, anyway...
		if (mvt >= 2){
			mvt = mvt - 2;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else 
		{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	default:
		break;
	}
}

/* Moves for the Dwarves */

void Algo::initializeDwarfMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints)
{
	int i, j;
	for (i = 0; i < size; i++)
	{
		for (j = 0; j < size; j++)
		{
			moves[i*size + j] = INIT_SPACE;
		}
	}
	for (i = 0; i < size; i++)
	{
		for (j = 0; j < size; j++)
		{
			moves[i*size + j] = 0;
		}
	}
	moves[x*size + y] = INIT_SPACE;
	costs[x*size + y] = movePoints;
	dwarfPossibleMovement(map, size, x, y, moves, costs);
}
void Algo::dwarfPossibleMovement(int* map, int size, int x, int y, int* moves, double* costs)
{
	// Spaces above
	if (x != 0)
	{
		// Above left
		if (moves[(x - 1)*size + y] == INIT_SPACE){
			dwarfMovement(map, costs, size, (x - 1), y, costs[(x - 1)*size + y], moves);
			dwarfPossibleMovement2(map, size, (x - 1), y, moves, costs);
		}
		// Above right
		if (y != size - 1)
		{
			if (moves[(x - 1)*size + (y + 1)] == INIT_SPACE)
			{
				dwarfMovement(map, costs, size, (x - 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
				dwarfPossibleMovement2(map, size, (x - 1), y, moves, costs);
			}
		}
	}
	if (y != 0)
	{
		// Space on the left
		if (moves[x*size + (y - 1)] == INIT_SPACE){
			dwarfMovement(map, costs, size, x, (y - 1), costs[x*size + (y - 1)], moves);
			dwarfPossibleMovement2(map, size, x, (y - 1), moves, costs);
		}
	}
	if (y != size - 1)
	{
		// Space on the right
		if (moves[x*size + (y + 1)] == INIT_SPACE){
			dwarfMovement(map, costs, size, x, (y + 1), costs[x*size + (y + 1)], moves);
			dwarfPossibleMovement2(map, size, x, (y + 1), moves, costs);
		}
	}
	// Spaces below
	if (x = !size - 1)
	{
		// Below left
		if (moves[(x + 1)*size + y - 1] == INIT_SPACE)
		{
			dwarfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			dwarfPossibleMovement2(map, size, (x + 1), (y - 1), moves, costs);
		}
		// Below right
		if (moves[(x + 1)*size + (y - 1)] == INIT_SPACE)
		{
			dwarfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			dwarfPossibleMovement2(map, size, (x + 1), (y - 1), moves, costs);
		}
	}
}
void Algo::dwarfPossibleMovement2(int* map, int size, int x, int y, int* moves, double* costs)
{
	// Spaces above
	if (x != 0)
	{
		// Above left
		if (moves[(x - 1)*size + y] == INIT_SPACE){
			dwarfMovement(map, costs, size, (x - 1), y, costs[(x - 1)*size + y], moves);
		}
		// Above right
		if (y != size - 1)
		{
			if (moves[(x - 1)*size + (y + 1)] == INIT_SPACE)
			{
				dwarfMovement(map, costs, size, (x - 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
			}
		}
	}
	if (y != 0)
	{
		// Space on the left
		if (moves[x*size + (y - 1)] == INIT_SPACE){
			dwarfMovement(map, costs, size, x, (y - 1), costs[x*size + (y - 1)], moves);
		}
	}
	if (y != size - 1)
	{
		// Space on the right
		if (moves[x*size + (y + 1)] == INIT_SPACE){
			dwarfMovement(map, costs, size, x, (y + 1), costs[x*size + (y + 1)], moves);
		}
	}
	// Spaces below
	if (x = !size - 1)
	{
		// Below left
		if (moves[(x + 1)*size + y - 1] == INIT_SPACE)
		{
			dwarfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
		}
		// Below right
		if (moves[(x + 1)*size + (y - 1)] == INIT_SPACE)
		{
			dwarfMovement(map, costs, size, (x + 1), (y + 1), costs[(x - 1)*size + (y + 1)], moves);
		}
	}
}

void Algo::dwarfMovement(int* map, double* costs, int size, int x, int y, double movePoints, int* moves)
{
	double mvt = movePoints;
	switch (map[size*x + y])
	{
	case FIELD_SPACE:
		if (mvt >= 0.5){
			mvt = mvt - 0.5;
			moves[x*size + y] = BEST_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case MOUNTAIN_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case FOREST_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	case DESERT_SPACE:
		if (mvt >= 1){
			mvt--;
			moves[x*size + y] = POSSIBLE_SPACE;
			costs[x*size + y] = mvt;
		}
		else{
			moves[x*size + y] = IMPOSSIBLE_SPACE;
		}
		break;
	default:
		break;
	}
}