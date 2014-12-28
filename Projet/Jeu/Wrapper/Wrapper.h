#ifndef __WRAPPER__
#define __WRAPPER__

#include "../Library/Algo.h"
#pragma comment(lib, "../Debug/Library.lib")
using namespace System;

namespace Wrapper {

	public ref class WrapperAlgo {
	private:
		Algo* algo;

	public:
		WrapperAlgo(){ algo = new Algo(); }
		~WrapperAlgo(){ delete(algo); }

		int** WrapperFillMap(int size){ return algo->fillMap(size); }
		int* WrapperInitialCoord(int* map, int size) { return algo->initialCoord(map, size); }

		void WrapperOrcMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints) 
		{
			return algo->initializeOrcMvt(map, size, x, y, costs, moves, movePoints);
		}

		void WrapperElfMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints)
		{
			return algo->initializeElfMvt(map, size, x, y, costs, moves, movePoints);
		}

		void WrapperDwarfMvt(int * map, int size, int x, int y, double * costs, int * moves, double movePoints)
		{
			return algo->initializeDwarfMvt(map, size, x, y, costs, moves, movePoints);
		}
	};
}
#endif