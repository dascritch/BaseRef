'use strict';

// first step, is it a modern browser ?
describe('can you run the tests ?', function() {
	it('XMLHttpRequest', function() {
		expect(typeof XMLHttpRequest).toBe('function');
	});
	it('JSON', function() {
		expect(typeof JSON).toBe('object');
		expect(typeof JSON.parse).toBe('function');
	});
});

// second step, loading tests definitions, agnostics specifications in JSON
var specifications;

describe( 'initializations', function() {
	var manifest = new XMLHttpRequest();
	manifest.open('GET', './specifications.json' , false);
	manifest.send();
	specifications = JSON.parse( manifest.responseText );

	it('specifications are loaded' , function() {
		expect( typeof specifications ).toBe('object');
	});
	it('BaseRef is ready' , function() {
		expect( typeof BaseRef ).toBe('function');
	});
});

var baseref = new BaseRef();

// main course

/** IMPORTANT : due to the nature of testing in javascript, we CAN'T use a direct code
	we MUST use a async method. This was both true in Jasmine and qUnit
**/
var originalTimeout;
beforeEach(function() {
  originalTimeout = jasmine.DEFAULT_TIMEOUT_INTERVAL;
  jasmine.DEFAULT_TIMEOUT_INTERVAL = 100;
});

afterEach(function() {
  jasmine.DEFAULT_TIMEOUT_INTERVAL = originalTimeout;
});

function test_value_for_method(function_name,tests,trythis) {
	it('BaseRef.'+function_name +'( '+String(trythis)+' ) = '+String(tests[trythis])  , function(done) {
		expect( baseref[function_name](trythis) )
		.toBe( tests[trythis] );
		done();
	});
}

function test_for_method(function_name,tests) {
	describe('BaseRef.'+function_name, function() {
		for(var trythis in tests) {
			test_value_for_method(function_name,tests,trythis);
		}
	});
}

for (var function_name in specifications) {
	test_for_method(function_name,specifications[function_name]);
}
