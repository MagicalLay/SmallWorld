#pragma once

class Algo {
public:
	Algo() {} // Builder
	~Algo() {} // Destroyer

	int** fillMap(int size);
	int* initialCoord(int* map, int size);

	void initializeOrcMvt(int * map, int size, int x, int y, double * cost, int * moves, double movePoints);
	void orcPossibleMovement(int* map, int size, int x, int y, int* moves, double* costs);
	void orcPossibleMovement2(int* map, int size, int x, int y, int* moves, double* costs);
	void orcMovement(int* map, double* costs, int size, int x, int y, double movePoints, int* moves);
	void initializeElfMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints);
	void elfPossibleMovement(int* map, int size, int x, int y, int* moves, double* costs);
	void elfPossibleMovement2(int* map, int size, int x, int y, int* moves, double* costs);
	void elfMovement(int* map, double* costs, int size, int x, int y, double movePoints, int* moves);
	void initializeDwarfMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints);
	void dwarfPossibleMovement(int* map, int size, int x, int y, int* moves, double* costs);
	void dwarfPossibleMovement2(int* map, int size, int x, int y, int* moves, double* costs);
	void dwarfMovement(int* map, double* costs, int size, int x, int y, double movePoints, int* moves);
};