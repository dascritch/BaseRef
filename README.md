Base Ref
========
Utilities to transcode a integer from and to base 10 to a alphanumerical base where the handwritten numbers won't have potential homoglyphes. It was first developed in a defunct service called “dAgence” as base 33 for generating command references, hence the “base ref” name.
It is actually a base 29.

This project is just an exercice (TDD and implementation in numerous languages), but you can use it and fork it. A work-in-progress (french written) post will be published during autumn 2014.

But if you find it really useful, I'll be happy.

Author : [Xavier "dascritch" Mouton-Dubosc](http://dascritch.com)

Principles
----------
The “conventionnal” base 36 uses numbers then letters : `0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ`

I'm removing any letter that may be confused with numbers when (badly) handwritten :`BILOSYZ`

We have 29 available glyphes : `0123456789ACDEFGHJKMNPQRTUVWX`

Intentions
----------
* Coding rules are : TDD, DRY, safe
* Is it possible to do TDD in various languages with only one specification file ?
* Do tests suite have different behaviours ?
* What language is smartest to read afterwards ?
* Ok, it's OOP, but have we smartests patterns ?
* How Json is decoded ?

API
---
The class should implements :

* `isValid`(string)
 * true : if a string has the glyphes even lowercase or a empty string
 * false  : elsewhere
* `encode`(absolute integer)
 * string : the translated string
 * false : if not an absolute integer, like real or negative numbers or NaN
* `decode`(string)
 * integer : the transcoded number
 * false : if not translatable
It may have an `exception` for debug purposes

Implementations
---------------
* Javascript (with QUnit and Jasmine)
* Python 3
* DOING : PHP (with Atoum)

Noted issues
------------
* Javascript and Python are NOT enumerating tests in the same order as the `specifications.json` file. Really depends or they respective interpretors. PHP do it right.
* Javascript tests must be in autonomous functions, due to the fact that paramaters in functions are references, and so the async'ed nature of tests made string erroneous.
* Python is so simple to substringing that's simply let Javascript far behind ; think of `substr` and `substring` confusion.
* No ternary operator in Python.
* Strangely, PHP doesn't accept strict comparison between a floored int and an int : `$b10 = (int) $b10; if ( ($b10<0) || (floor($b10) != $b10) )` .
* in PHP::`decode($based)`, `$based` should be casted as string (`strtoupper()` do the job), seems that `json_decode()` saw `"0"` and `"9"` as integers !
* Noted (and corrected, that is the exercise goal) typos in documentations :
 * [QUnit](https://github.com/jquery/qunitjs.com/pull/77)
 * [Atoum](https://github.com/atoum/atoum/pull/345)

Licence
-------
Copyright (C) 2014 Xavier "dascritch" Mouton-Dubosc

This software is licenced under the [GNU General Purpose Licence](http://www.gnu.org/licenses/gpl-3.0.txt).
Use it and deploy it as you want : i've done too much closed source before.

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

Versions
--------
Repository : <https://github.com/dascritch/BaseRef>

Keeping in touch
----------------
* professional : <http://dascritch.com>
* blog : <http://dascritch.net>
* twitter : [@dascritch](https://twitter.com/dascritch)