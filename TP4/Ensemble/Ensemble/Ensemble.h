#pragma once
#ifndef ENSEMBLE_H
#define ENSEMBLE_H
#include "list.h"
#include <iostream>

template <class T> class List;

template <class T> class Ensemble {

private:
	List<T> ens;

public:

	Ensemble() {
		this.ens = new List();
	}

	Ensemble(const List<T>& lref) {
		this.ens = new List()
		ListIterator<T> LI = lref.beg();
		int i = 0;
		for (int i; i < lref.card(); i++) {
			T e = LI.get();
			this.add(e);
			LI++;
		}
	}

	void add(T elem) {
		if (!this.ens==elem) this.ens.addElement(e, -1);
	}

	Ensemble<T> operator+(const Ensemble& v) const {
		Ensemble res = new Ensemble(this.ens);
		ListIterator<T> lI = v.ens.beg();
		int i = 0;
		for (int i; i < this.ens.getCard(); i++) {
			T e = LI.get();
			res.add(e);
		}
		return res;
	}

	std::ostream& operator<<(std::ostream& out, const Ensemble<T>& lref) {
		out << lref.ens.card() << "    ";
		for (ListIterator<T> iterlst = lref.ens.beg(); !(iterlst.finished()); ++iterlst) {
			out << iterlst.get() << "  ";
		}
		return out;
	}

	template <class T>
	std::istream& operator>>(std::istream& in, Ensemble<T>& lref) {
		int nb;
		in >> nb;
		for (int i = 0; i < nb; i++) {
			T tmp;
			in >> tmp;
			lref.add(tmp);
		}
		return in;
	}

};

#endif