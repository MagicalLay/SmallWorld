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
		int computeFoo() { return algo->computeFoo(); }
		int** fillMap(int size) { return algo->fillMap(size); }
	};
}
#endif