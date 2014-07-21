Doing
-----
* Post mortem on blog
* blog on XHR/CSP/CORS issues per browsers
* blog on error reporting per browsers
* blog on json decoding and key ordering by languages (interesting !)
* blog on per languages issues, like json_decoding in php (i never noticied it !)

Actual bugs
-----------

* Asynchronous tests in javascript, both qunit and jasmine
* Better `specifications.json` loading for javascripts tests. No XHR

Noted issues
------------
* Javascript and Python are NOT enumerating tests in the same order as the `specifications.json` file. Really depends or they respective interpretors. PHP do it right.
* Javascript tests must be in autonomous functions, due to the fact that paramaters in functions are references, and so the async'ed nature of tests made string erroneous.
* Python is so simple to substringing that's simply let Javascript far behind ; think of `substr` and `substring` confusion.
* No ternary operator in Python.
* In Python, (standard) pow(int,int) returns an integer, where math.pow(int,int) returns a real
* Strangely, PHP doesn't accept strict comparison between a floored int and an int : `$b10 = (int) $b10; if ( ($b10<0) || (floor($b10) != $b10) )` .
* in PHP::`decode($based)`, `$based` should be casted as string (`strtoupper()` do the job), seems that `json_decode()` saw `"0"` and `"9"` as integers !
* Noted (and corrected, that is the exercise goal) typos in documentations :
 * [QUnit](https://github.com/jquery/qunitjs.com/pull/77)
 * [Atoum](https://github.com/atoum/atoum/pull/345)

TODO implementations
--------------------

* Ruby
* Rust
* Dart
* Go
* ZSH or Bash
* PSQL

