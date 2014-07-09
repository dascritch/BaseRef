'use strict';

// first step, is it a modern browser ?

test( 'can you run the tests ?', function() {
	ok(XMLHttpRequest , 'XMLHttpRequest yay');
	ok(JSON , 'JSON yay');
	ok(JSON.parse , 'JSON.parse ... yes, we\'re in the third millenium !');
});

// second step, loading tests definitions, agnostics specifications in JSON

var specifications;

// TODO should be in the test, as async loading

var manifest = new XMLHttpRequest();
manifest.open('GET', './specifications.json' , false);
manifest.send();
specifications = JSON.parse( manifest.responseText );

test( 'initializations', function() {
	equal(typeof specifications, 'object', 'specifications are loaded');
	equal(typeof BaseRef, 'function', 'BaseRef is ready');
});

var baseref = new BaseRef();

// main course

/** IMPORTANT : due to the nature of testing in javascript, we CAN'T use a direct code
	we MUST use a async method. This was both true in Jasmine and qUnit
**/

function test_for_method(function_name,tests) {
	QUnit.asyncTest( 'BaseRef.'+function_name, function( assert ) {
		var tries = 0;
		for(var trythis in tests) tries++;
  		expect( tries );

		for(var trythis in tests) {
			assert.equal(
				baseref[function_name](trythis) ,
				tests[trythis] ,
				'BaseRef.'+function_name +'( '+String(trythis)+' ) = '+String(tests[trythis])
			);
		}
		 QUnit.start();
	});
}

for (var function_name in specifications) {
	test_for_method(function_name,specifications[function_name])
}
