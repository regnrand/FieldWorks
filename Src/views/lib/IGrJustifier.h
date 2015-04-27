/*--------------------------------------------------------------------*//*:Ignore this sentence.
Copyright (c) 2003-2015 SIL International
This software is licensed under the LGPL, version 2.1 or later
(http://www.gnu.org/licenses/lgpl-2.1.html)

File: IGrJustifier.h
Responsibility: Sharon Correll
Last reviewed: Not yet.

Description:
	An interface for a justification agent that is used by the Graphite engine.
-------------------------------------------------------------------------------*//*:End Ignore*/
#ifdef _MSC_VER
#pragma once
#endif
#ifndef IGRJUSTIFIER_INCLUDED
#define IGRJUSTIFIER_INCLUDED

#include "GrResult.h"

namespace gr
{

class GraphiteProcess;

/*----------------------------------------------------------------------------------------------
	Class: IGrJustifier
	This class provides an interface for a justification agent for the Graphite engine.
----------------------------------------------------------------------------------------------*/
class IGrJustifier
{
public:
	virtual ~IGrJustifier() {};
	virtual GrResult adjustGlyphWidths(GraphiteProcess * pgje, int iGlyphMin, int iGlyphLim,
		float dxCurrWidth, float dxDesiredWidth) = 0;

	//virtual GrResult suggestShrinkAndBreak(GraphiteProcess * pfgjwe,
	//	int iGlyphMin, int iGlyphLim, float dxsWidth, LgLineBreak lbPref, LgLineBreak lbMax,
	//	float * pdxShrink, LgLineBreak * plbToTry) = 0;

	// Return a Graphite-compatible justifier that can be stored in a Graphite segment.
	// TODO: remove
	//virtual void JustifierObject(IGrJustifier ** ppgjus) = 0;

	// When a segment is being destroyed, delete this object, which is the wrapper for the
	// text source inside of it.
	// TODO: remove
	//virtual void DeleteJustifierPtr() = 0;
};

} // namespace gr

#if defined(GR_NO_NAMESPACE)
using namespace gr;
#endif

#endif // !IGRJUSTIFIER_INCLUDED