#pragma once
#include <string>
class OverflowException
{

private :
	std::string reason;

public:
	OverflowException();
	~OverflowException();

};

